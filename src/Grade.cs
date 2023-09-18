

namespace CourseProject;

public class Grade
{

    public static readonly int UndefinedWeight = -999999;
    public static readonly int UndefinedQuantity = 0;
    public enum GradeType
    {
        SevenStep12,
        SevenStep10,
        SevenStep7,
        SevenStep4,
        SevenStep02,
        SevenStep00,
        SevenStepMinus3,
        Passed,
        Failed,
        Absent,
        Sick,
        NotApproved
    }
    public enum OutcomeType
    {
        Pass,
        Fail,
        Absent
    }
    private static readonly Dictionary<GradeType, (string, float, OutcomeType)> GradeConfig = new()
    {
        { GradeType.SevenStep12, ("Grade12", 12, OutcomeType.Pass) },
        { GradeType.SevenStep10, ("Grade10", 10, OutcomeType.Pass) },
        { GradeType.SevenStep7, ("Grade7", 7, OutcomeType.Pass) },
        { GradeType.SevenStep4, ("Grade4", 4, OutcomeType.Pass) },
        { GradeType.SevenStep02, ("Grade02", 2, OutcomeType.Pass) },
        { GradeType.SevenStep00, ("Grade00", 0, OutcomeType.Fail) },
        { GradeType.SevenStepMinus3, ("GradeMinus3", -3, OutcomeType.Fail) },
        { GradeType.Passed, ("GradePassed", UndefinedWeight, OutcomeType.Pass) },
        { GradeType.Failed, ("GradeFailed", UndefinedWeight, OutcomeType.Fail) },
        { GradeType.Absent, ("GradeAbsent", UndefinedWeight, OutcomeType.Absent) },
        { GradeType.Sick, ("GradeSick", UndefinedWeight, OutcomeType.Absent) },
        { GradeType.NotApproved, ("GradeNotApproved", UndefinedWeight, OutcomeType.Absent) },
    };
    public string Name { get; }
    public float NumericalWeight { get; }
    public bool HasNumericWeight { get; }
    public OutcomeType ExamOutcome { get; }
    public int Quantity { get; set; }

    private Grade(string name, float weight, OutcomeType outcome)
    {
        Name = name;
        NumericalWeight = weight;
        HasNumericWeight = weight != UndefinedWeight;
        ExamOutcome = outcome;
        Quantity = UndefinedQuantity;
    }

    public static Grade CreateGrade(GradeType gradeType)
    {
        var (name, weight, examStatus) = GradeConfig[gradeType];
        return new Grade(name, weight, examStatus);
    }

    public static List<Grade> GradeCollection()
    {
        List<Grade> list = new();
        foreach (GradeType gradeType in Enum.GetValues(typeof(GradeType)))
        {
            list.Add(CreateGrade(gradeType));
        }
        return list;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}