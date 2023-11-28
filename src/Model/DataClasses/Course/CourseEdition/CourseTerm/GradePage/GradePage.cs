

namespace CourseProject;

public class GradePage
{
    public string ID { get; }
    public string Name { get; }
    public string ExamPeriod { get; }
    public List<string> OtherVersions { get; }
    public List<Grade> GradeList { get; }
    public string LastUpdated { get; }

    public GradePage(IGradeParser dataParser)
    {
        ID = dataParser.ID;
        Name = dataParser.Name;
        ExamPeriod = dataParser.ExamPeriod;
        OtherVersions = dataParser.OtherVersions;
        GradeList = dataParser.GradeList;
        LastUpdated = dataParser.LastUpdated;
    }

    public static GradePage CreateEmpty()
    {
        IGradeParser setDefaultValues = new GradeDefaults();
        return new GradePage(setDefaultValues);
    }
}