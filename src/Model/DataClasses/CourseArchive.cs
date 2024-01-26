

namespace CourseProject;

public class CourseArchive
{
    public AcademicYear AcademicYear { get; }
    public Dictionary<string, string> Courses { get; }

    public CourseArchive(CourseArchiveParser dataParser)
    {
        AcademicYear = dataParser.AcademicYear;
        Courses = dataParser.Courses;
    }
}