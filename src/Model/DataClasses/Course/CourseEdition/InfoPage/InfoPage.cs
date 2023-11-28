

namespace CourseProject;

public class InfoPage
{
    public string ID { get; }
    public string Name { get; }
    public string Year { get; }
    public string Announcement { get; }
    public string StudyLines { get; }
    public Dictionary<string,string> InfoTableContent { get; }
    public string LastUpdated { get; }

    public InfoPage(IInfoParser dataParser)
    {
        ID = dataParser.ID;
        Name = dataParser.Name;
        Year = dataParser.Year;
        Announcement = dataParser.Announcement;
        StudyLines = dataParser.StudyLines;
        InfoTableContent = dataParser.InfoTableContent;
        LastUpdated = dataParser.LastUpdated;
    }

    public static InfoPage CreateEmpty()
    {
        IInfoParser setDefaultValues = new InfoDefaults();
        return new InfoPage(setDefaultValues);
    }
}