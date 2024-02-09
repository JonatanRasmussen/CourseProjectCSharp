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

    public void ScrapeAll()
    {
        ScrapeArchiveVolumes();
        var volumes = Persistence.Instance.GetArchiveVolumesList();
        foreach (string volume in volumes)
        {
            var academicYear = AcademicYearFactory.CreateFromYearRange(volume);
            ScrapeAllForYear(academicYear);
        }
    }

    public void ScrapeAllForYear(AcademicYear academicYear)
    {
        ScrapeCourseArchive(academicYear);
        ScrapeInfo(academicYear);
        ScrapeEvalUrlSearch(academicYear);
        foreach (Term term in academicYear.Terms)
        {
            ScrapeEvals(term);
            ScrapeGrades(term);
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
        CombineCourseArchive();
        Persistence.WriteCourseHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    public void ScrapeEvals(Term term)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(term.AcademicYear);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseEvalUrl(term, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteEvalHtml(PageSources, term);
        PageSources.Clear();
    }

    public void ScrapeGrades(Term term)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(term.AcademicYear);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseGradeUrl(term, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteGradeHtml(PageSources, term);
        PageSources.Clear();
    }

    public void ScrapeInfo(AcademicYear academicYear)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(academicYear);
        foreach (string courseCode in courseList)
        {
            string url = UrlManagement.GetCourseInfoUrl(academicYear, courseCode);
            Urls.Add(url);
        }
        ProcessUrls();
        Persistence.WriteInfoHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    public void ScrapeEvalUrlSearch(AcademicYear academicYear)
    {
        PageSources.Clear();
        List<string> courseList = Persistence.Instance.GetCourseList(academicYear);
        foreach (string courseCode in courseList)
        {
            Urls.Add(courseCode);
        }
        ProcessUrls();
        Persistence.WriteHrefDigitsHtml(PageSources);
        PageSources.Clear();
    }

    private void ProcessUrls()
    {
        using IWebDriver webDriver = InitializeWebDriver(timeOutDurationMilliseconds);
        using HttpClient httpClient = InitializeHttpClient(timeOutDurationMilliseconds);
        foreach (string url in Urls)
        {
            IUrlAccessStrategy urlAccessStrategy = SelectUrlAccessStrategy(url);
            string pageSource = urlAccessStrategy.Execute(url, sleepDurationMilliseconds, httpClient, webDriver);
            PageSources[url] = pageSource;
        }
        Urls.Clear();
    }

    private void CombineCourseArchive()
    {
        // DTU's Course archive cannot display all courses on one page
        // Instead, we have a page for all courses starting with A, and B, and C, and so on
        // This method joins all the page sources together into one big page source.
        string archiveVolumesUrl = UrlManagement.ArchiveVolumesUrl;
        string archiveVolumesHtml = PageSources[archiveVolumesUrl];
        string url = UrlManagement.GetUrlForArchiveVolumes();
        ArchiveVolumesParser archiveVolumesParser = new(archiveVolumesHtml, url);
        List<string> yearRanges = archiveVolumesParser.YearRanges;
        foreach(string yearRange in yearRanges)
        {
            // Join letter A, B, C, ... Z page sources for each academic year
            CombineCourseArchiveForSpecifiedYear(yearRange);
        }
    }
    private void CombineCourseArchiveForSpecifiedYear(string yearRange)
    {
        AcademicYear academicYear = AcademicYearFactory.CreateFromYearRange(yearRange);
        List<string> urls = UrlManagement.GetCourseArchiveUrls(academicYear);
        string key = UrlManagement.GetUrlForSpecificVolume(academicYear);
        string value = "";
        foreach (var url in urls)
        {
            value += PageSources[url];
        }
        PageSources[key] = value;
    }

    private static IWebDriver InitializeWebDriver(int timeOutInSeconds)
    {
        ChromeOptions options = new()
        {
            PageLoadStrategy = PageLoadStrategy.Normal
        };
        options.AddArgument("--disable-extensions");
        using IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(timeOutInSeconds);
        return driver;
    }

    private static HttpClient InitializeHttpClient(int timeOutInSeconds)
    {
        using HttpClient httpClient = new();
        httpClient.Timeout = TimeSpan.FromSeconds(timeOutInSeconds);
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