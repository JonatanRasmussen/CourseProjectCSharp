

namespace CourseProject;

public class Grade
{
    public static readonly int UndefinedWeight = -999999;
    public string Name { get; }
    public float NumericalWeight { get; }
    public bool HasNumericWeight { get; }
    public GradeResult Result { get; }
    public int Quantity { get; private set; }

    public Grade(string name, float weight, GradeResult result)
    {
        Name = name;
        NumericalWeight = weight;
        HasNumericWeight = weight != UndefinedWeight;
        Result = result;
        Quantity = 0;
    }

    public static List<Grade> GradeCollection()
    {
        List<Grade> list = new();
        foreach (GradeType gradeType in Enum.GetValues(typeof(GradeType)))
        {
            list.Add(GradeFactory.CreateGrade(gradeType));
        }
        return list;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public bool IsEmpty()
    {
        if (Name == GradeFactory.CreateEmpty().Name)
        {
            return true;
        }
        return false;
    }
}