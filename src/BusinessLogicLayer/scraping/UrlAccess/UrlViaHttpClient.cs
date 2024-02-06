using OpenQA.Selenium;

namespace CourseProject;

public class AccessUrlViaHttpClient : IUrlAccessStrategy
{
    public string Execute(string url, int sleepDurationMilliseconds, HttpClient httpClient, IWebDriver driver)
    {
        try
        {
            var pageSource = GetPageSource(url, httpClient).Result; // Use .Result to block and get the result synchronously
            Task.Delay(sleepDurationMilliseconds).Wait(); // Add delay to ensure the page has loaded completely
            return pageSource;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return string.Empty;
        }
    }

    static async Task<string> GetPageSource(string url, HttpClient httpClient)
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Failed to fetch page source. Status code: {response.StatusCode}");
        }
    }
}