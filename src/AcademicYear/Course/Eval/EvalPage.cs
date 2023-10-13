

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

    public EvalPage(IEvalFetcher dataFetcher)
    {
        ID = dataFetcher.ID;
        Name = dataFetcher.Name;
        Term = dataFetcher.Term;
        CouldRespond = dataFetcher.CouldRespond;
        DidRespond = dataFetcher.DidRespond;
        ShouldNotRespond = dataFetcher.ShouldNotRespond;
        LastUpdated = dataFetcher.LastUpdated;
        EvalList = dataFetcher.EvalList;
        EvalWebsiteUrlNumber = dataFetcher.EvalWebsiteUrlNumber;
    }
}