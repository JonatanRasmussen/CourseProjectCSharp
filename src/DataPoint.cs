

namespace CourseProject;


public interface IDataPoint
{
    string CustomName  { get; }
    string Parse();
}

public class DataPoint : IDataPoint
{

    public static string WebsiteEnglishKey { get; }
    public static string WebsiteDanishKey { get; }
    public static readonly string CustomName = "Yo";

    public DataPoint(string name)
    {
        Name = name;
    }

    public static string Parse()
    {
        string sep = "__";
        return sep;
    }
}