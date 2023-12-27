

namespace CourseProject;

public class InfoStatistics
{
    private static readonly int NonNumericEmptyValue = -99999;
    public Dictionary<string,string> InfoTableContent { get; }


    public InfoStatistics(IInfoParser dataParser)
    {
        InfoTableContent = dataParser.InfoTableContent;

    }
}