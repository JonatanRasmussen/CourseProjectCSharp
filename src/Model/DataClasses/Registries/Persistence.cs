using System.Text.Json;

namespace CourseProject;

public static class Persistence
{
    private static readonly string ScrapedHtmlFolder = "database/html/";
    private static readonly Dictionary<string, Dictionary<string, string>> fileContentCache = new();

    public static string GetEvalHtml(Term term, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadEvalJson(() => OpenEvalHtmlJson(term), term);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {EvalFileName(term)}.");
    }

    public static string GetGradeHtml(Term term, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadGradeJson(() => OpenGradeHtmlJson(term), term);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {GradeFileName(term)}.");
    }

    public static string GetInfoHtml(AcademicYear year, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadInfoJson(() => OpenInfoHtmlJson(year), year);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {InfoFileName(year)}.");
    }

    private static Dictionary<string, string> GetOrReadEvalJson(Func<Dictionary<string, string>> jsonOpener, Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{EvalFileName(term)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private static Dictionary<string, string> GetOrReadGradeJson(Func<Dictionary<string, string>> jsonOpener, Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{GradeFileName(term)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private static Dictionary<string, string> GetOrReadInfoJson(Func<Dictionary<string, string>> jsonOpener, AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{InfoFileName(year)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private static Dictionary<string, string> GetOrReadJsonInternal(Func<Dictionary<string, string>> jsonOpener, string filePath)
    {
        lock (fileContentCache)
        {
            if (fileContentCache.TryGetValue(filePath, out var cachedContent))
            {
                return cachedContent;
            }

            var content = jsonOpener.Invoke();
            fileContentCache[filePath] = content;
            return content;
        }
    }

    private static Dictionary<string, string> OpenEvalHtmlJson(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{EvalFileName(term)}";
        return ReadJson(filePath);
    }

    private static Dictionary<string, string> OpenGradeHtmlJson(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{GradeFileName(term)}";
        return ReadJson(filePath);
    }

    private static Dictionary<string, string> OpenInfoHtmlJson(AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{InfoFileName(year)}";
        return ReadJson(filePath);
    }

    private static Dictionary<string, string> ReadJson(string filePath)
    {
        Dictionary<string, string>? jsonDict;
        jsonDict = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText($"{filePath}.json"));
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