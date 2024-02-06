

namespace CourseProject;

public class ArchiveVolumesParser : IArchiveVolumesParser
{
    private string PageSource { get; }
    public List<string> YearRanges { get; }

    public ArchiveVolumesParser(string html)
    {
        PageSource = html;
        YearRanges = ParseYearRanges();
    }

    private List<string> ParseYearRanges()
    {
        string start = "<a\\s+href=\"/archive/\\d{4}-\\d{4}\">\\s*";
        string middle = "(\\d{4}/\\d{4})";
        string end = "</a>";
        string pattern = $"{start}{middle}{end}";
        return ParserUtils.GetList(pattern, PageSource);
    }
}