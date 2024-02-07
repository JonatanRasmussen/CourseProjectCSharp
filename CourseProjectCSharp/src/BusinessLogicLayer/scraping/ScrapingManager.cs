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
        { UrlManagement.EvaluationsSearchUrl, new AccessUrlViaHttpClient() },
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

    public void ScrapeCourseArchive(AcademicYear academicYear)
    {
        PageSources.Clear();
        Urls.AddRange(UrlManagement.CourseArchive(academicYear));
        ProcessUrls();
        CombineCourseArchive();
        Persistence.WriteCourseHtml(PageSources, academicYear);
        PageSources.Clear();
    }

    public void ProcessUrls()
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

    public void CombineCourseArchive()
    {
        // DTU's Course archive cannot display all courses on one page
        // Instead, we have a page for all courses starting with A, and B, and C, and so on
        // This method joins all the page sources together into one big page source.
        string archiveVolumesUrl = UrlManagement.ArchiveVolumesUrl;
        string archiveVolumesHtml = PageSources[archiveVolumesUrl];
        IArchiveVolumesParser archiveVolumesParser = new ArchiveVolumesParser(archiveVolumesHtml);
        List<string> yearRanges = archiveVolumesParser.YearRanges;
        foreach(string yearRange in yearRanges)
        {
            // Join letter A, B, C, ... Z page sources for each academic year
            CombineCourseArchiveForSpecifiedYear(yearRange);
        }
    }
    public void CombineCourseArchiveForSpecifiedYear(string yearRange)
    {
        AcademicYear academicYear = AcademicYearFactory.CreateFromYearRange(yearRange);
        List<string> urls = UrlManagement.CourseArchive(academicYear);
        string value = "";
        foreach (var url in urls)
        {
            value += PageSources[url];
        }
        PageSources[yearRange] = value;
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
            if (url.StartsWith(domainStrategyPair.Key, StringComparison.OrdinalIgnoreCase))
            {
                return domainStrategyPair.Value;
            }
        }
        return new EmptyUrlAccessStrategy();
    }
}