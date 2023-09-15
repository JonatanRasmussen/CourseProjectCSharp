

namespace CourseProject;


public interface IDataSet<TEnum> where TEnum : Enum
{
    TEnum DataPoint { get; set; }
    string Html();
}

public class DataSet : IDataSet
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