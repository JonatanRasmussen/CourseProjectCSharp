using System.Text.Json;

namespace CourseProject;

public static class Persistence
{
    private static readonly string ScrapedHtmlFolder = "todo/todo/";


    public static Dictionary<string,string> ScrapedEvals(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{EvalFileName(term)}";
        return ReadJson(filePath);
    }

    public static Dictionary<string,string> ScrapedGrades(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{GradeFileName(term)}";
        return ReadJson(filePath);
    }

    public static Dictionary<string,string> ScrapedInfo(AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{InfoFileName(year)}";
        return ReadJson(filePath);
    }

    private static Dictionary<string, string> ReadJson(string filePath)
    {
        Dictionary<string, string>? jsonDict;
        jsonDict = JsonSerializer.Deserialize<Dictionary<string, string>>($"{filePath}.json");
        if (jsonDict == null)
        {
            throw new NullReferenceException($"Null reference for '{filePath}'");
        }
        return jsonDict;
    }

    private static void WriteJson(string filePath, Dictionary<string, string> nestedDict)
    {
        try
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string json = JsonSerializer.Serialize(nestedDict, options);
            File.WriteAllText($"{filePath}.json", json);
        }
        catch (Exception ex)
        {
            throw new JsonException($"Json file '{filePath}' caught exception {ex}");
        }
    }

    private static string EvalFileName(Term term)
    {
        return $"{term.Name}__evals.json";
    }

    private static string GradeFileName(Term term)
    {
        return $"{term.Name}__grades.json";
    }

    private static string InfoFileName(AcademicYear year)
    {
        return $"{year.Name}__info.json";
    }

}