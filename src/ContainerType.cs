

namespace CourseProject;

public abstract class ContainerType
{
    public Domain Domain { get; }
    public abstract string ClassName { get; }
    public abstract List<Type> PrimaryChildTypes { get; }
    public ContainerType(Domain domain)
    {
        Domain = domain;
    }
}

public class School : ContainerType
{
    public School(Domain domain) : base(domain)
    {
    }

    public override string ClassName => "test1";

    public override List<Type> PrimaryChildTypes => new() {typeof(Year)};
}

public class Year : ContainerType
{
    public Year(Domain domain) : base(domain)
    {
    }

    public override string ClassName => "test2";

    public override List<Type> PrimaryChildTypes => new() { typeof(School) };
}

public class StudyLine : ContainerType
{
    public StudyLine(Domain domain) : base(domain)
    {
    }

    public override string ClassName => "test2";

    public override List<Type> PrimaryChildTypes => new() { typeof(School) };
}