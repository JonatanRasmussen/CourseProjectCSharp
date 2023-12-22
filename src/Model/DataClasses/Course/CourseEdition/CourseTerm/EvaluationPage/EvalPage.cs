

namespace CourseProject;

public class EvalPage
{
    public CourseMetaData MetaData { get; }
    public EvalResponseRate ResponseRate { get; }
    public List<Eval> EvalList { get; }
    public int EvalWebsiteUrlNumber { get; }

    public EvalPage(IEvalParser dataParser)
    {
        MetaData = CourseMetaDataFactory.CreateFromEvalParser(dataParser);
        ResponseRate = CreateResponseData(dataParser);
        EvalList = dataParser.EvalList;
        EvalWebsiteUrlNumber = dataParser.EvalWebsiteUrlNumber;
    }

    public static EvalPage CreateEmpty()
    {
        IEvalParser setDefaultValues = new EvalDefaults();
        return new EvalPage(setDefaultValues);
    }

    private static EvalResponseRate CreateResponseData(IEvalParser dataParser)
    {
        int couldRespond = dataParser.CouldRespond;
        int didRespond = dataParser.DidRespond;
        int shouldNotRespond = dataParser.ShouldNotRespond;
        return new(couldRespond, didRespond, shouldNotRespond);
    }
}