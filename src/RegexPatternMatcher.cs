using System.Text;
using System.Text.RegularExpressions;

namespace CourseProject;

public static class PatternMatcher
{

    public static readonly string PatternNotFound = "Info not available";

    public static string Get(string pattern, string html, int groupIndex)
    {
        Regex regex = new Regex(pattern, RegexOptions.Singleline);
        Match match = regex.Match(html);
        if (match.Success)
        {
            return match.Groups[groupIndex].Value.Trim();
        }
        else
        {
            return PatternNotFound;
        }
    }

    public static string TrimHtmlAndGet(string pattern, string html, int groupIndex)
    {
        string singleLineHtml = RemoveNewlines(html);
        string singleSpaceHtml = RemoveMultiSpaces(singleLineHtml);
        return Get(pattern, singleSpaceHtml, groupIndex);
    }

    public static string EscapeSpecialCharacters(string input)
    {
        StringBuilder escapedString = new StringBuilder();
        string specialCharacters = @".*+()[]{}|^$?\";
        foreach (char c in input)
        {
            if (specialCharacters.Contains(c))
            {
                escapedString.Append("\\");
            }
            escapedString.Append(c);
        }
        return escapedString.ToString();
    }

    public static string RemoveNewlines(string input)
    {
        return input.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
    }

    public static string RemoveMultiSpaces(string input)
    {
        return Regex.Replace(input, " {2,}", "");
    }
}