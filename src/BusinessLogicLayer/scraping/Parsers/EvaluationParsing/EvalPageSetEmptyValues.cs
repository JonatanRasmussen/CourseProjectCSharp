

namespace CourseProject;

public class EvalDefaults : IEvalParser
{
    public string ID { get; }
    public string Name { get; }
    public string Term { get; }
    public int CouldRespond { get; }
    public int DidRespond { get; }
    public int ShouldNotRespond { get; }
    public string LastUpdated { get; }
    public List<Eval> EvalList { get; }
    public int EvalWebsiteUrlNumber { get; }
    public EvalDefaults()
    {
        ID = string.Empty;
        Name = string.Empty;
        Term = string.Empty;
        CouldRespond = -1;
        DidRespond = -1;
        ShouldNotRespond = -1;
        LastUpdated = string.Empty;
        EvalList = new();
        EvalWebsiteUrlNumber = -1;
    }
}