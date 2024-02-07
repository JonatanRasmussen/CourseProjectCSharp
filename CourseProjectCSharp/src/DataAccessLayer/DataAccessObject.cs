using System.Text.Json;

namespace CourseProject;

public class DataAccessObject
{
    public List<string> GetCourseList(AcademicYear year)
    {
        string unparsedHtml = Persistence.Instance.GetCourseHtml(year);
        return new(); //TODO
    }
}