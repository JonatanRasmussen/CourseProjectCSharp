

namespace CourseProject;

public class EvaluationPage
{
    public string ID { get; }
    public string Name { get; }
    public string Term { get; }
    public int CouldRespond { get; }
    public int DidRespond { get; }
    public int ShouldNotRespond { get; }
    public string LastUpdated { get; }
    public List<Evaluation> EvaluationList { get; }
    public int EvaluationWebsiteUrlNumber { get; }

    public EvaluationPage(IEvaluationFetcher dataFetcher)
    {
        ID = dataFetcher.ID;
        Name = dataFetcher.Name;
        Term = dataFetcher.Term;
        CouldRespond = dataFetcher.CouldRespond;
        DidRespond = dataFetcher.DidRespond;
        ShouldNotRespond = dataFetcher.ShouldNotRespond;
        LastUpdated = dataFetcher.LastUpdated;
        EvaluationList = dataFetcher.EvaluationList;
        EvaluationWebsiteUrlNumber = dataFetcher.EvaluationWebsiteUrlNumber;
    }
}