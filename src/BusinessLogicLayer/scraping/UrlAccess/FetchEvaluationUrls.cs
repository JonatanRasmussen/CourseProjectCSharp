using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CourseProject;

public static class FetchEvaluationUrls
{
    private static readonly int PageLoadTimeoutSeconds = 5;
    private static readonly int SleepDurationMilliseconds = 1100;

    public static List<(string LinkText, string Href)> Execute(string courseCode)
    {
        string URL = "https://evaluering.dtu.dk/CourseSearch";
        string COURSE_INPUT = "//*[@id='CourseCodeTextbox']";
        string SEARCH_SUBMIT = "//*[@id='SearchButton']";
        List<(string LinkText, string Href)> evaluationUrls = new List<(string LinkText, string Href)>();
        ChromeOptions options = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Normal
        };
        options.AddArgument("--disable-extensions"); // Optional: Disable extensions if needed
        using (IWebDriver driver = new ChromeDriver(options))
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeoutSeconds);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.XPath(COURSE_INPUT)).SendKeys(courseCode);
            driver.FindElement(By.XPath(SEARCH_SUBMIT)).Click();

            Thread.Sleep(SleepDurationMilliseconds); // Add delay to ensure the page has loaded completely
            var links = driver.FindElements(By.TagName("a"));
            foreach (var link in links)
            {
                var href = link.GetAttribute("href");
                var linkText = link.Text;
                if (!string.IsNullOrEmpty(href) && href.Length >= 33 && href.Substring(0, 33) == "https://evaluering.dtu.dk/kursus/")
                {
                    evaluationUrls.Add((linkText, href));
                }
            }
        }
        return evaluationUrls;
    }
}