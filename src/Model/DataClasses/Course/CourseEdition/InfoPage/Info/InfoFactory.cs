

namespace CourseProject;

public class InfoFactory
{
    public static readonly Dictionary<InfoTypePrimaryTable,string> PrimaryTableKeys = InfoParser.DtuWebsitePrimaryTableKeysEnglish;

    public static readonly Dictionary<InfoTypeSecondaryTable,string> SecondaryTableKeys = InfoParser.DtuWebsiteSecondaryTableKeysEnglish;

    public static readonly Dictionary<Info.SecondaryTableInfoType, string> DtuWebsiteSecondaryTableKeysEnglish = new()
    {
        {Info.SecondaryTableInfoType.GeneralCourseObjectives, "General course objectives"},
        {Info.SecondaryTableInfoType.LearningObjectives, "Learning objectives"},
        {Info.SecondaryTableInfoType.Content, "Content"},
        {Info.SecondaryTableInfoType.CourseLiterature, "CourseLiterature"},
        {Info.SecondaryTableInfoType.Remarks, "Remarks"},
    };

    public static Info CreateInfo(string tableKey, string value)
    {
        return new Info(tableKey, value);
        var primaryTableKey = PrimaryTableKeys.FirstOrDefault(x => x.Value.Equals(tableKey)).Key;
        if (primaryTableKey != null)
        {
            value = PrimaryTableKeys[primaryTableKey];
        }
        var secondaryTableKey = SecondaryTableKeys.FirstOrDefault(x => x.Value.Equals(tableKey)).Key;
        if (secondaryTableKey != null)
        {
            value = SecondaryTableKeys[secondaryTableKey];
        }
    }

    public static Info CreateEmpty()
    {
        return CreateInfo(string.Empty, string.Empty);
    }
}