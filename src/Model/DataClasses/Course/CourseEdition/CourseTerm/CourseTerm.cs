

namespace CourseProject;

public class CourseTerm
{
    public string ID { get; }
    public string Name { get; }
    public string ExamPeriod { get; }

    public CourseTerm()
    {
        ID = string.Empty;
        Name = string.Empty;
        ExamPeriod = string.Empty;
    }
}