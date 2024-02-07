using System.Text.Json;

namespace CourseProject;

public class Persistence
{
    // Persistence class implements the Singleton pattern to provide access to file-based data persistence.
    private static readonly Persistence instance = new(); // Singleton instance of the class.
    public static Persistence Instance => instance; // Public access to the Singleton
    private readonly Dictionary<string, Dictionary<string, string>> fileContentCache = new();
    public readonly string ScrapedHtmlFolder = "database/html/";

    public string GetCourseHtml(AcademicYear year)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadCourseJson(() => OpenCourseHtmlJson(year), year);
        if (htmlDictionary.TryGetValue(year.Name, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{year.Name}' does not exist in {CourseFileName(year)}.");
    }

    public string GetEvalHtml(Term term, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadEvalJson(() => OpenEvalHtmlJson(term), term);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {EvalFileName(term)}.");
    }

    public string GetGradeHtml(Term term, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadGradeJson(() => OpenGradeHtmlJson(term), term);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {GradeFileName(term)}.");
    }

    public string GetInfoHtml(AcademicYear year, string courseCode)
    {
        Dictionary<string, string> htmlDictionary = GetOrReadInfoJson(() => OpenInfoHtmlJson(year), year);
        if (htmlDictionary.TryGetValue(courseCode, out string? value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key '{courseCode}' does not exist in {InfoFileName(year)}.");
    }

    public static void WriteCourseHtml(Dictionary<string, string> dict, AcademicYear year)
    {
        string filePath = CourseFileName(year);
        WriteJson(filePath, dict);
    }

    public static void WriteEvalHtml(Dictionary<string, string> dict, Term term)
    {
        string filePath = EvalFileName(term);
        WriteJson(filePath, dict);
    }

    public static void WriteGradeHtml(Dictionary<string, string> dict, Term term)
    {
        string filePath = GradeFileName(term);
        WriteJson(filePath, dict);
    }

    public static void WriteInfoHtml(Dictionary<string, string> dict, AcademicYear year)
    {
        string filePath = InfoFileName(year);
        WriteJson(filePath, dict);
    }


    private Dictionary<string, string> GetOrReadCourseJson(Func<Dictionary<string, string>> jsonOpener, AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{CourseFileName(year)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private Dictionary<string, string> GetOrReadEvalJson(Func<Dictionary<string, string>> jsonOpener, Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{EvalFileName(term)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private Dictionary<string, string> GetOrReadGradeJson(Func<Dictionary<string, string>> jsonOpener, Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{GradeFileName(term)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private Dictionary<string, string> GetOrReadInfoJson(Func<Dictionary<string, string>> jsonOpener, AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{InfoFileName(year)}";
        return GetOrReadJsonInternal(jsonOpener, filePath);
    }

    private Dictionary<string, string> GetOrReadJsonInternal(Func<Dictionary<string, string>> jsonOpener, string filePath)
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

    private Dictionary<string, string> OpenCourseHtmlJson(AcademicYear year)
    {
        string filePath = $"{ScrapedHtmlFolder}{CourseFileName(year)}";
        return ReadJson(filePath);
    }

    private Dictionary<string, string> OpenEvalHtmlJson(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{EvalFileName(term)}";
        return ReadJson(filePath);
    }

    private Dictionary<string, string> OpenGradeHtmlJson(Term term)
    {
        string filePath = $"{ScrapedHtmlFolder}{GradeFileName(term)}";
        return ReadJson(filePath);
    }

    private Dictionary<string, string> OpenInfoHtmlJson(AcademicYear year)
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

    private static void WriteJson(string filePath, Dictionary<string, string> dict)
    {
        try
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            string json = JsonSerializer.Serialize(dict, options);
            File.WriteAllText($"{filePath}", json);
        }
        catch (Exception ex)
        {
            throw new JsonException($"Json file '{filePath}' caught exception {ex}");
        }
    }

    private static string CourseFileName(AcademicYear year)
    {
        return $"{year.Name}__courses.json";
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