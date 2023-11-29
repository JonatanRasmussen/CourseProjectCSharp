

namespace CourseProject;

public class EvalPage
{
    public CourseMetaData MetaData { get; }
    public EvalResponseRate ResponseRate { get; }
    public List<Eval> EvalList { get; }
    public int EvalWebsiteUrlNumber { get; }

    public EvalPage(IEvalParser dataParser)
    {
        MetaData = CreateMetaData(dataParser);
        ResponseRate = CreateResponseData(dataParser);
        EvalList = dataParser.EvalList;
        EvalWebsiteUrlNumber = dataParser.EvalWebsiteUrlNumber;
    }

    public static EvalPage CreateEmpty()
    {
        IEvalParser setDefaultValues = new EvalDefaults();
        return new EvalPage(setDefaultValues);
    }

    private static CourseMetaData CreateMetaData(IEvalParser dataParser)
    {
        string code = dataParser.ID;
        string name = dataParser.Name;
        string time = dataParser.Term;
        string lastUpdated = dataParser.LastUpdated;
        return new(code, name, time, lastUpdated);
    }

    private static EvalResponseRate CreateResponseData(IEvalParser dataParser)
    {
        int couldRespond = dataParser.CouldRespond;
        int didRespond = dataParser.DidRespond;
        int shouldNotRespond = dataParser.ShouldNotRespond;
        return new(couldRespond, didRespond, shouldNotRespond);
    }
}