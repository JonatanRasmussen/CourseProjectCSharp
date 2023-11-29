

namespace CourseProject;

public class GradeStatistics
{
    public List<Grade> GradeList { get; }

    public GradeStatistics(List<Grade> gradeList)
    {
        GradeList = gradeList;
    }
}