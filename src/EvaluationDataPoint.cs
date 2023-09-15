

namespace CourseProject;

public static class EvalDataPointNames
{
    public static readonly Dictionary<EvalDataPoint, string> RenamedKeys = HtmlEvaluationParser.DtuWebsiteEvalDataPoints;
}

public enum EvalDataPoint
{
    CourseID,
    CourseName,
    Term,
    CouldAnswer,
    DidAnswer,
    ShouldNotAnswer,
    Q11,
    Q12,
    Q13,
    Q14,
    Q15,
    Q21,
}