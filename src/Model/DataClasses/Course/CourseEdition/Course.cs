

namespace CourseProject;

public class Course
{
    public CourseMetaData CourseMetaData { get; }
    public string Name { get; }
    public string Time { get; }
    public string LastUpdated { get; }
    public Course()
    {
        CourseMetaData = CourseMetaData.InitializeEmpty();
        Name = string.Empty;
        Time = string.Empty;
        LastUpdated = string.Empty;
    }
}