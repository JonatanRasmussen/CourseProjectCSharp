

namespace CourseProject;

public class Grade
{
    public string Name { get; }
    public int? NumericalWeight { get; }
    public bool PassesExam { get; }
    public bool AttendedExam { get; set; }
    public int Quantity { get; set; }

    private Grade(string name, int? weight, bool passed, int quantity)
    {
        Name = name;
        NumericalWeight = weight;
        PassesExam = passed;
        Quantity = quantity;
        AttendedExam = true;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    public static Grade Grade12(int quantity)
    {
        return new Grade("Grade12", 12, true, quantity);
    }

    public static Grade Grade10(int quantity)
    {
        return new Grade("Grade10", 10, true, quantity);
    }

    public static Grade Grade7(int quantity)
    {
        return new Grade("Grade7", 7, true, quantity);
    }

    public static Grade Grade4(int quantity)
    {
        return new Grade("Grade4", 4, true, quantity);
    }

    public static Grade Grade02(int quantity)
    {
        return new Grade("Grade02", 2, true, quantity);
    }

    public static Grade Grade0(int quantity)
    {
        return new Grade("Grade0", 0, false, quantity);
    }

    public static Grade GradeMinus3(int quantity)
    {
        return new Grade("GradeMinus3", -3, false, quantity);
    }

    public static Grade Passed(int quantity)
    {
        return new Grade("Passed", null, true, quantity);
    }

    public static Grade Failed(int quantity)
    {
        return new Grade("Failed", null, false, quantity);
    }

    public static Grade Absent(int quantity)
    {
        return new Grade("Absent", null, false, quantity) { AttendedExam = false };
    }

    public static Grade Sick(int quantity)
    {
        return new Grade("Sick", null, false, quantity) { AttendedExam = false };
    }

    public static Grade NotApproved(int quantity)
    {
        return new Grade("NotApproved", null, false, quantity) { AttendedExam = false };
    }
}