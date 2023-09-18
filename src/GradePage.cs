

namespace CourseProject;

public class GradePage
{
    public string ID { get; }
    public string Name { get; }
    public string ExamPeriod { get; }
    public List<string> OtherVersions { get; }
    public List<Grade> GradeList { get; }
    public string LastUpdated { get; }

    public GradePage(IGradeFetcher dataFetcher)
    {
        ID = dataFetcher.ID;
        Name = dataFetcher.Name;
        ExamPeriod = dataFetcher.ExamPeriod;
        OtherVersions = dataFetcher.OtherVersions;
        GradeList = dataFetcher.GradeList;
        LastUpdated = dataFetcher.LastUpdated;
    }
}