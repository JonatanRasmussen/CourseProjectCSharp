

namespace CourseProject;

public class Term
{
    public enum TermType
    {
        E,
        F,
    }
    public string Name { get; }
    public TermType Season { get; }
    public AcademicYear Year { get; }
    public Course Course { get; }
    public EvalPage EvalPage { get; }
    public GradePage GradePage { get; }
    public Term()
    {

    }
    private string GenerateName(TermType season, AcademicYear academicYear)
    {
        switch (season)
        {
            case TermType.E:
                return $"E{academicYear.StartYear - 2000}";
            case TermType.F:
                return $"F{academicYear.StartYear + 1 - 2000}";
            default:
                throw new ArgumentOutOfRangeException(nameof(season), "Invalid day of the week");
        }
    }
}