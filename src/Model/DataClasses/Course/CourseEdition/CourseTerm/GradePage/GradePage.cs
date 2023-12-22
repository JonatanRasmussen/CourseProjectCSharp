

namespace CourseProject;

public class GradePage
{
    public CourseMetaData MetaData { get; }
    public List<Grade> GradeList { get; }
    public List<string> OtherVersions { get; }

    public GradePage(IGradeParser dataParser)
    {
        MetaData = CourseMetaDataFactory.CreateFromGradeParser(dataParser);
        GradeList = dataParser.GradeList;
        OtherVersions = dataParser.OtherVersions;
    }

    public static GradePage CreateEmpty()
    {
        IGradeParser setDefaultValues = new GradeDefaults();
        return new GradePage(setDefaultValues);
    }
}