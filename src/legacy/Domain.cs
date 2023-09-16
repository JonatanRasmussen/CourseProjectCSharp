

namespace CourseProject;

public class Domain
{
    public string Name { get; }

    public Domain(string name)
    {
        Name = name;
    }

    public static string CreateUniqueID()
    {
        string sep = "__";
        return sep;
    }
}