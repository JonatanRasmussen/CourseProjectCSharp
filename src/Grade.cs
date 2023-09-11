

namespace CourseProject;

public class Grade
{
    public string Name { get; }
    public int NumericalWeight { get; }
    public bool PassesExam { get; }
    public int Quantity { get; set; }
    public bool CountsAsExamAttendance { get; set; }

    private Grade(string name, int weight, bool passed, int quantity)
    {
        Name = name;
        NumericalWeight = weight;
        PassesExam = passed;
        Quantity = quantity;
        CountsAsExamAttendance = true;
    }
    public static Grade Grade12(int quantity)
    {
        return new Grade("Grade12", 12, true, quantity);
    }
}