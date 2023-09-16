

namespace CourseProject;

public abstract class Label
{
    public Domain Domain { get; }
    public string Name { get; }

    public Label(Domain domain)
    {
        Domain = domain;
        Name = GenerateName();
    }

    private string GenerateName()
    {
        string sep = "__";
        return Domain.Name + sep + SubclassName();
    }

    public abstract string SubclassName();
}