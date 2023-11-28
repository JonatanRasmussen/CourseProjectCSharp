

namespace CourseProject;

public class EvalPage
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

    public EvalPage(IEvalParser dataParser)
    {
        ID = dataParser.ID;
        Name = dataParser.Name;
        Term = dataParser.Term;
        CouldRespond = dataParser.CouldRespond;
        DidRespond = dataParser.DidRespond;
        ShouldNotRespond = dataParser.ShouldNotRespond;
        LastUpdated = dataParser.LastUpdated;
        EvalList = dataParser.EvalList;
        EvalWebsiteUrlNumber = dataParser.EvalWebsiteUrlNumber;
    }

    public static EvalPage CreateEmpty()
    {
        IEvalParser setDefaultValues = new EvalDefaults();
        return new EvalPage(setDefaultValues);
    }
}