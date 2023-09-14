

namespace CourseProject;

public static class HtmlEvaluationParser
{
    public static Dictionary<string, string> ParseAllEvaluationData(string htmlContent)
    {
        return new()
        {
            ["test"] = ParseX(htmlContent)
        };
    }

    public static string ParseX(string htmlContent)
    {
        string pattern = "<div class=\"bar\">General course objectives</div>(.*?)</div>";
        return PatternMatcher.Get(htmlContent, pattern, 1);
    }
}