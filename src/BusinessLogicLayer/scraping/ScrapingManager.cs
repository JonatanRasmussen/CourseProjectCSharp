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
    public Dictionary<string, string> UrlPageSources { get; set; }
    private readonly int timeOutDurationMilliseconds = 5000;
    private readonly int sleepDurationMilliseconds = 1100;


    public ScrapingManager()
    {
        Urls = new();
        UrlPageSources = new();
    }

    public void ProcessUrls()
    {
        using IWebDriver webDriver = InitializeWebDriver(timeOutDurationMilliseconds);
        using HttpClient httpClient = InitializeHttpClient(timeOutDurationMilliseconds);
        foreach (var url in Urls)
        {
            IUrlAccessStrategy urlAccessStrategy = SelectUrlAccessStrategy(url);
            string pageSource = urlAccessStrategy.Execute(url, sleepDurationMilliseconds, httpClient, webDriver);
            UrlPageSources[url] = pageSource;
        }
        Urls.Clear();
    }

    public void CombineCourseArchive()
    {
        string archiveVolumesUrl = UrlManagement.ArchiveVolumesUrl;
        string archiveVolumesHtml = UrlPageSources[archiveVolumesUrl];
        IArchiveVolumesParser archiveVolumesParser = new ArchiveVolumesParser(archiveVolumesHtml);
        List<string> yearRanges = archiveVolumesParser.YearRanges;
        foreach(string yearRange in yearRanges)
        {
            CombineCourseArchiveForSpecifiedYear(yearRange);
        }
    }
    public void CombineCourseArchiveForSpecifiedYear(string yearRange)
    {
        AcademicYear academicYear = AcademicYearFactory.CreateFromYearRange(yearRange);
        List<string> urls = UrlManagement.CourseArchive(academicYear);
        string key = UrlManagement.GetUrlForSpecificVolume(academicYear);
        string value = "";
        foreach (var url in urls)
        {
            value += UrlPageSources[url];
        }
        UrlPageSources[key] = value;
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