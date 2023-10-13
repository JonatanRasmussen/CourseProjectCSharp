

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

    public InfoPage(IInfoFetcher dataFetcher)
    {
        ID = dataFetcher.ID;
        Name = dataFetcher.Name;
        Year = dataFetcher.Year;
        Announcement = dataFetcher.Announcement;
        StudyLines = dataFetcher.StudyLines;
        InfoTableContent = dataFetcher.InfoTableContent;
        LastUpdated = dataFetcher.LastUpdated;
    }
}