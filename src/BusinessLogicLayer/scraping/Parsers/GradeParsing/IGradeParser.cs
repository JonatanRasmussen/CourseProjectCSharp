

namespace CourseProject;

public interface IGradeParser
{
    string ID { get; }
    string Name { get; }
    string ExamPeriod { get; }
    List<string> OtherVersions { get; }

    string LastUpdated { get; }
    List<Grade> GradeList { get; }
}