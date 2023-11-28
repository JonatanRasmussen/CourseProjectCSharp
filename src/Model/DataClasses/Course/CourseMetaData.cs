using System.Globalization;

namespace CourseProject;

public class CourseMetaData
{
    public string Code { get; }
    public string Name { get; }
    public string FullTitle { get; }
    public string Time { get; }
    public TimeInterval TimeInterval { get; }
    public string LastUpdated { get; }
    private DateTime LastUpdatedDateTime { get; }

    public CourseMetaData(string code, string name, string time, string lastUpdated)
    {
        Code = code;
        Name = name;
        FullTitle = $"{code} {name}";
        TimeInterval = TimeInterval.CreateTimeIntervalFromString(time);
        Time = TimeInterval.Name;
        LastUpdatedDateTime = ParseLastUpdated(lastUpdated);
        LastUpdated = LastUpdatedDateTime.ToString("dd MMM yyyy");
    }

    public static CourseMetaData CreateEmpty()
    {
        string emptyCode = string.Empty;
        string emptyName = string.Empty;
        string emptyTime = string.Empty;
        string emptyDate = string.Empty;
        return new(emptyCode, emptyName, emptyTime, emptyDate);
    }

    private static DateTime ParseLastUpdated(string lastUpdated)
    {
        string dateString = lastUpdated;
        string format = "dd MMM yyyy";
        var danishCulture = new CultureInfo("da-DK");

        if (DateTime.TryParseExact(dateString, format, danishCulture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            Console.WriteLine($"Error: Failed to parse the date '{lastUpdated}'");
            var defaultDate = new DateTime(1970, 1, 1, 0, 0, 0);
            return defaultDate;
        }
    }
}