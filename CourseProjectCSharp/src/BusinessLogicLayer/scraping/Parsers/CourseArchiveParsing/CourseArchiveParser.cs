

namespace CourseProject;

public class CourseArchiveParser
{
    private string PageSource { get; }
    public string Url { get; }
    //public AcademicYear AcademicYear { get; }
    //public string Letter { get; }
    //public Dictionary<string,string> Courses { get; }
    public CourseArchiveParser(string html, string url)
    {
        PageSource = html;
        Url = url;
        //AcademicYear = ParseAcademicYear();
        //Letter = ParseLetter();
        //Courses = ParseCourses();
    }

}