using System.Net.Http;

namespace CourseProject;

public class AccessUrlByHttpClient : IUrlAccessStrategy
{
    public string Execute(string url)
    {
        try
        {
            var pageSource = GetPageSource(url).Result; // Use .Result to block and get the result synchronously
            Task.Delay(1100).Wait(); // Add delay to ensure the page has loaded completely
            return pageSource;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return string.Empty;
        }
    }

    static async Task<string> GetPageSource(string url)
    {
        using HttpClient httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(5);
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