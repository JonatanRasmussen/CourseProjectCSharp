using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CourseProject;

public class AccessUrlByWebBrowser : IUrlAccessStrategy
{
    public string Execute(string url)
    {
        try
        {
            return GetPageSource(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return string.Empty;
        }
    }

    static string GetPageSource(string url)
    {
        ChromeOptions options = new ChromeOptions();
        options.PageLoadStrategy = PageLoadStrategy.Normal;
        options.AddArgument("--disable-extensions"); // Optional: Disable extensions if needed

        using IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl(url);
        Thread.Sleep(1100); // Add delay to ensure the page has loaded completely
        return driver.PageSource;
    }
}