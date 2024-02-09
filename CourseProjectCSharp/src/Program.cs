using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;

namespace CourseProject;

class Program
{
    public static Dictionary<string,string> Execute(string courseCode, int sleepDurationMilliseconds, IWebDriver driver)
    {
        string URL = "https://evaluering.dtu.dk/CourseSearch";
        string COURSE_INPUT = "//*[@id='CourseCodeTextbox']";
        string SEARCH_SUBMIT = "//*[@id='SearchButton']";
        Dictionary<string, string> evaluationUrls = new();
        driver.Navigate().GoToUrl(URL);
        driver.FindElement(By.XPath(COURSE_INPUT)).SendKeys(courseCode);
        driver.FindElement(By.XPath(SEARCH_SUBMIT)).Click();
        Thread.Sleep(sleepDurationMilliseconds);

        // If only 1 evaluation exists, the driver is automatically redirected to it
        // Which means that instead of search results, we get an evaluation page.
        // The parser is set up to handle this special case, so be careful with modifications to this code
        if (driver.Url.StartsWith(UrlManagement.EvaluationsUrl))
        {
            // Parse redirected eval page
            EvalParser parser = new(driver.PageSource, driver.Url);
            string key = $"{parser.TermCode}__{parser.ID}";
            string value = driver.Url;
            evaluationUrls[key] = value;
        }
        else
        {
            // Parse search results
            var links = driver.FindElements(By.TagName("a"));
            foreach (var link in links)
            {
                var href = link.GetAttribute("href");
                var linkText = link.Text;
                if (!string.IsNullOrEmpty(href) && href.Length >= 33 && href[..33] == "https://evaluering.dtu.dk/kursus/")
                {
                    var parsedLinkText = ModifyLinkText(linkText);
                    evaluationUrls[parsedLinkText] = href;
                }
            }
        }
        // Scuffed string-convertion to match the return type specified by the interface.
        // A deserialization happens in the parser.
        return evaluationUrls;
    }

    private static string ModifyLinkText(string linkText)
    {
        string courseCode = string.Empty;
        string termCode = $"{linkText[0]}{linkText[2]}{linkText[3]}";
        string[] linkTextComponents = linkText.Split(' ');
        if (linkTextComponents.Length >= 2)
        {
            courseCode = linkTextComponents[1];
        }
        return $"{termCode}__{courseCode}";
    }

    private static IWebDriver InitializeWebDriver(int timeOutInSeconds)
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

    static void Main(string[] args)
    {
        using (IWebDriver webDriver = InitializeWebDriver(5000))
        {
            Dictionary<string,string> pageSource = Execute("02977", 5000, webDriver);
            foreach (var (key, value) in pageSource)
            {
                Console.WriteLine($"Link Text: {key}");
                Console.WriteLine($"Href: {value}");
                Console.WriteLine();
            }
        }
        //var urlAccessStrategy = new UrlViaHttpClient();
        //string url = "https://evaluering.dtu.dk/kursus/10603/289317";
        //string pageSource = urlAccessStrategy.FetchPageSource(url);
        //Console.WriteLine($"{pageSource}");

        //var testObject = ConcreteFactory.GetInstance((1, "example"));
        //var anotherObject = CopyConcreteFactory.GetInstance((2,"hey"));
        //Console.WriteLine($"{testObject.Str}");
        //Console.WriteLine($"{anotherObject.Str}");
    }
}

public class PersonTestClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public PersonTestClass(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}