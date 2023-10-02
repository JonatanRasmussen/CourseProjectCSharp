

namespace CourseProject;

public interface IInfoFetcher
{
    string ID { get; }
    string Name { get; }
    string Year { get; }
    string Announcement { get; }
    string StudyLines { get; }
    Dictionary<string,string> InfoTableContent { get; }
    string LastUpdated { get; }
}

public class InfoFetcher : IInfoFetcher
{
    private string PageSource { get; }
    public string ID { get; }
    public string Name { get; }
    public string Year { get; }
    public string Announcement { get; }
    public string StudyLines { get; }
    public Dictionary<string,string> InfoTableContent { get; }
    public string LastUpdated { get; }

    public InfoFetcher()
    {
        PageSource = HtmlFetcher.Get();
        ID = ParseCourseIdInfo();
        Name = ParseCourseNameInfo();
        Year = ParseYearInfo();
        Announcement = ParseAnnouncementInfo();
        StudyLines = ParseStudyLinesInfo();
        InfoTableContent = ParseAllTableInfo();
        LastUpdated = ParseLastUpdatedInfo();
    }

    public static readonly Dictionary<Info.PrimaryTableInfoType, string> DtuWebsitePrimaryTableKeysEnglish = new()
    {
        {Info.PrimaryTableInfoType.DanishTitle, "Danish title"},
        {Info.PrimaryTableInfoType.LanguageOfInstruction, "Language of instruction"},
        {Info.PrimaryTableInfoType.Ects, "Point( ECTS )"},
        {Info.PrimaryTableInfoType.CourseType, "Course type"},
        {Info.PrimaryTableInfoType.Location, "Location"},
        {Info.PrimaryTableInfoType.ScopeAndForm, "Scope and form"},
        {Info.PrimaryTableInfoType.DurationOfCourse, "Duration of Course"},
        {Info.PrimaryTableInfoType.DateOfExamination, "Date of examination"},
        {Info.PrimaryTableInfoType.TypeOfAssessment, "Type of assessment"},
        {Info.PrimaryTableInfoType.ExamDuration, "Exam duration"},
        {Info.PrimaryTableInfoType.Aid, "Aid"},
        {Info.PrimaryTableInfoType.Evaluation, "Evaluation"},
        {Info.PrimaryTableInfoType.Responsible, "Responsible"},
        {Info.PrimaryTableInfoType.CourseCoResponsible, "Course co-responsible"},
        {Info.PrimaryTableInfoType.Department, "Department"},
        {Info.PrimaryTableInfoType.HomePage, "Home page"},
        {Info.PrimaryTableInfoType.RegistrationSignUp, "Registration Sign up"},
        {Info.PrimaryTableInfoType.GreenChallengeParticipation, "Green challenge participation"},
        {Info.PrimaryTableInfoType.Schedule, "Schedule"},
        {Info.PrimaryTableInfoType.NotApplicableTogetherWith, "Not applicable together with"},
        {Info.PrimaryTableInfoType.RecommendedPrerequisites, "Recommended prerequisites"},
        {Info.PrimaryTableInfoType.PreviousCourse, "Previous Course"},
        {Info.PrimaryTableInfoType.ParticipantsRestrictions, "Participants restrictions"},
        {Info.PrimaryTableInfoType.MandatoryPrerequisites, "Mandatory Prerequisites"},
        {Info.PrimaryTableInfoType.DepartmentInvolved, "Department involved"},
        {Info.PrimaryTableInfoType.ExternalInstitution, "External Institution"},
    };

    public static readonly Dictionary<Info.SecondaryTableInfoType, string> DtuWebsiteSecondaryTableKeysEnglish = new()
    {
        {Info.SecondaryTableInfoType.GeneralCourseObjectives, "General course objectives"},
        {Info.SecondaryTableInfoType.LearningObjectives, "Learning objectives"},
        {Info.SecondaryTableInfoType.Content, "Content"},
        {Info.SecondaryTableInfoType.CourseLiterature, "CourseLiterature"},
        {Info.SecondaryTableInfoType.Remarks, "Remarks"},
    };

    public Dictionary<string, string> ParseAllTableInfo()
    {
        Dictionary<string, string> dct = new();
        foreach (var infoType in DtuWebsitePrimaryTableKeysEnglish)
        {
            string key = infoType.Value;
            string value = ParseInfofromMainTable(key);
            dct.Add(key, value);
        }
        foreach (var infoType in DtuWebsiteSecondaryTableKeysEnglish)
        {
            string key = infoType.Value;
            string value = ParseInfofromSecondaryTable(key);
            dct.Add(key, value);
        }
        return dct;
    }

    public string ParseInfofromMainTable(string websiteKey)
    {
        string start = $"<tr><td><label>{websiteKey}</label></td><td>";
        string middle = "(.*?)";
        string end = "</td></tr>";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        string value = PatternMatcher.Get(pattern, PageSource, groupIndex);
        if (value != PatternMatcher.PatternNotFound)
        {
            return value;
        }
        else
        {
            start = $"<tr><td><label>{websiteKey}</label></td><td title=\"";
            middle = "(.*?)";
            end = "\">";
            pattern = $"{start}{middle}{end}";
            groupIndex = 1;
            return PatternMatcher.Get(pattern, PageSource, groupIndex);
        }
    }

    public string ParseInfofromSecondaryTable(string websiteKey)
    {
        string start = $"<div class=\"bar\">{websiteKey}</div>";
        string middle = "(.*?)";
        string end = "<div class=\"bar\">";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.Get(pattern, PageSource, groupIndex);
    }

    public string ParseLastUpdatedInfo()
    {
        string english_last_updated = "Last updated";
        string start = $"<div class=\"bar\">{english_last_updated}</div>";
        string middle = "(.*?)";
        string end = "</div></div></div>";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.Get(pattern, PageSource, groupIndex);
    }

    public string ParseCourseIdInfo()
    {
        string start = "<h2 style=\"font-family:verdana; font-size:18px; margin-bottom: 10px;\">";
        string middle = @"(\w{5})\s";
        string end = "";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.TrimHtmlAndGet(pattern, PageSource, groupIndex);
    }

    public string ParseCourseNameInfo()
    {
        string start = "<h2 style=\"font-family:verdana; font-size:18px; margin-bottom: 10px;\">";
        string middle =  @"\w{5}\s(.*?)";
        string end = "</h2></div>";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.TrimHtmlAndGet(pattern, PageSource, groupIndex);
    }

    public string ParseYearInfo()
    {
        string pattern = @"(\d{4}\/\d{4})";
        int groupIndex = 1;
        return PatternMatcher.Get(pattern, PageSource, groupIndex);
    }

    public string ParseAnnouncementInfo()
    {
        string start = "</h2></div></div><div class=\"row\"><div class=\"col-xs-12\">";
        string middle = "(.*?)";
        string end = "</div></div><div class=\"row\">";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.TrimHtmlAndGet(pattern, PageSource, groupIndex);
    }

    public string ParseStudyLinesInfo()
    {
        string start = "var lines =";
        string middle = "(.*?)";
        string end = ";var collectedTooltips = {};";
        string pattern = $"{start}{middle}{end}";
        int groupIndex = 1;
        return PatternMatcher.TrimHtmlAndGet(pattern, PageSource, groupIndex);
    }
}