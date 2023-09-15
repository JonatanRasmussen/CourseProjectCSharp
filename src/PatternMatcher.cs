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

    public static Dictionary<string, string> GetMultiple(string pattern, string html)
    {
        Dictionary<string, string> dct = new();
        Regex regex = new Regex(pattern, RegexOptions.Singleline);
        MatchCollection matchCollection = regex.Matches(html);

        foreach (Match match in matchCollection)
        {
            if (match.Success)
            {
                string option = match.Groups[1].Value;
                string optionCount = match.Groups[2].Value;
                dct.Add(option, optionCount);
            }
            else
            {
                dct.Add(PatternNotFound, PatternNotFound);
                break;
            }
        }
        return dct;
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

    public static string RemoveEscapeCharacters(string input)
    {
        return Regex.Unescape(input);
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