using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CourseProject;

public class ScrapingManager
{
    public static readonly Dictionary<string, IUrlAccessStrategy> DomainStrategyTable = new()
    {
        { UrlManagement.CourseBaseUrl, new AccessUrlViaWebBrowser() },
        { UrlManagement.GradesUrl, new AccessUrlViaHttpClient() },
        { UrlManagement.EvaluationsUrl, new AccessUrlViaHttpClient() },
        { UrlManagement.EvaluationsHrefDigitsUrl, new FetchEvaluationUrls() },
        { UrlManagement.CourseArchiveUrl, new AccessUrlViaHttpClient() },
    };
    public List<string> Urls { get; set; }
    public Dictionary<string, string> PageSources { get; set; }
    private readonly int timeOutDurationMilliseconds = 5000;
    private readonly int sleepDurationMilliseconds = 1100;


    public ScrapingManager()
    {
        Urls = new();
        PageSources = new();
    }

    public void ScrapeAll(string oldestYearRangeToScrape, int courseLimit)
    {
        ScrapeArchiveVolumes();
        var volumes = Persistence.Instance.GetArchiveVolumesList();
        foreach (string volume in volumes)
        {
            var academicYear = AcademicYearFactory.CreateFromYearRange(volume);
            ScrapeAllForYear(academicYear, courseLimit);
            if (academicYear.Name == oldestYearRangeToScrape)
            {
                Console.WriteLine($"Scraping was configured to stop after {oldestYearRangeToScrape}");
                break;
            }
        }
    }

    public void ScrapeAllForYear(AcademicYear academicYear, int courseLimit)
    {
        //ScrapeCourseArchive(academicYear);
        ScrapeInfo(academicYear, courseLimit);
        ScrapeEvalUrlSearch(academicYear, courseLimit);
        foreach (Term term in academicYear.Terms)
        {
            ScrapeEvals(term, courseLimit);
            ScrapeGrades(term, courseLimit);
        }
    }

    public void ScrapeArchiveVolumes()
    {
        PageSources.Clear();
        Urls.Add(UrlManagement.ArchiveVolumesUrl);
        ProcessUrls();
        Persistence.WriteArchiveVolumesHtml(PageSources);
        PageSources.Clear();
    }

    public void ScrapeCourseArchive(AcademicYear academicYear)
    {
        PageSources.Clear();
        Urls.AddRange(UrlManagement.GetCourseArchiveUrls(academicYear));
        ProcessUrls();
        CombineCourseArchiveForSpecifiedYear(academicYear);
        Persistence.WriteCourseHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    public void ScrapeEvals(Term term, int courseListMaxLength)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(term.AcademicYear, courseListMaxLength);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseEvalUrl(term, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteEvalHtml(PageSources, term);
        PageSources.Clear();
    }

    public void ScrapeGrades(Term term, int courseListMaxLength)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(term.AcademicYear, courseListMaxLength);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseGradeUrl(term, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteGradeHtml(PageSources, term);
        PageSources.Clear();
    }

    public void ScrapeInfo(AcademicYear academicYear, int courseListMaxLength)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(academicYear, courseListMaxLength);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseInfoUrl(academicYear, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteInfoHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    public void ScrapeEvalUrlSearch(AcademicYear academicYear, int courseListMaxLength)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(academicYear, courseListMaxLength);
        foreach (string courseCode in courseList)
        {
            Urls.Add(courseCode);
        }
        ProcessUrls();
        Persistence.WriteHrefDigitsHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    private void ProcessUrls()
    {
        IWebDriver webDriver = InitializeWebDriver(timeOutDurationMilliseconds);
        HttpClient httpClient = InitializeHttpClient(timeOutDurationMilliseconds);
        foreach (string url in Urls)
        {
            Console.WriteLine("Fetching Page Source of "+url);
            IUrlAccessStrategy urlAccessStrategy = SelectUrlAccessStrategy(url);
            string pageSource = urlAccessStrategy.Execute(url, sleepDurationMilliseconds, httpClient, webDriver);
            PageSources[url] = pageSource;
        }
        Urls.Clear();
        webDriver.Quit();
        httpClient.Dispose();
    }


    private void CombineCourseArchiveForSpecifiedYear(AcademicYear academicYear)
    {
        List<string> urls = UrlManagement.GetCourseArchiveUrls(academicYear);
        string key = UrlManagement.GetUrlForSpecificVolume(academicYear);
        string value = "";
        foreach (var url in urls)
        {
            value += PageSources[url];
        }
        PageSources[key] = value;
    }

    public static IWebDriver InitializeWebDriver(int timeOutInSeconds)
    {
        ChromeOptions options = new()
        {
            PageLoadStrategy = PageLoadStrategy.Normal
        };
        options.AddArgument("--disable-extensions");
        IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(timeOutInSeconds);
        return driver;
    }


    public static HttpClient InitializeHttpClient(int timeOutInSeconds)
    {
        HttpClient httpClient = new()
        {
            Timeout = TimeSpan.FromSeconds(timeOutInSeconds)
        };
        return httpClient;
    }

    private static IUrlAccessStrategy SelectUrlAccessStrategy(string url)
    {
        foreach (var domainStrategyPair in DomainStrategyTable)
        {
            if (url.Length == 5) // Special case for EvalUrlSearch
            {
                return DomainStrategyTable[UrlManagement.EvaluationsHrefDigitsUrl];
            }
            else if (url.StartsWith(domainStrategyPair.Key, StringComparison.OrdinalIgnoreCase))
            {
                return domainStrategyPair.Value;
            }
        }
        return new EmptyUrlAccessStrategy();
    }
}