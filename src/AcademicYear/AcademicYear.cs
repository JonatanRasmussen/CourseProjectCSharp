

namespace CourseProject;


public enum Domain
{
    DTU
}

public class AcademicYear
{
    public string Season { get; }
    public int StartYear { get; }
    public int EndYear { get; }
    public EvalPage EvalPage { get; }
    public GradePage GradePage { get; }
    public AcademicYear()
    {

    }
}