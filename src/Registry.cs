

namespace CourseProject;

public class Registry
{

    public Dictionary<string, EvalPage> EvalPages { get; set; }
    public Dictionary<string, GradePage> GradePages { get; set; }
    public Dictionary<string, InfoPage> InfoPages { get; set; }
    public Dictionary<string, Term> Terms { get; set; }
    public Dictionary<string, AcademicYear> Years { get; set; }

    public Registry()
    {
        EvalPages = new();
        GradePages = new();
        InfoPages = new();
        Terms = new();
        Years = new();
    }

    public void FillRegistries()
    {
        FillEvalRegistry();
        FillGradeRegistry();
        FillInfoRegistry();
    }

    private void FillEvalRegistry()
    {
        foreach (Term term in Terms.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedEvals(term);
            foreach (string html in pageSources.Values)
            {
                EvalFetcher evalFetcher = new(html);
                EvalPage evalPage = new(evalFetcher);
                EvalPages.Add(term.Name, evalPage);
            }
        }
    }

    private void FillGradeRegistry()
    {
        foreach (Term term in Terms.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedGrades(term);
            foreach (string html in pageSources.Values)
            {
                GradeFetcher gradeFetcher = new(html);
                GradePage gradePage = new(gradeFetcher);
                GradePages.Add(term.Name, gradePage);
            }
        }
    }

    private void FillInfoRegistry()
    {
        foreach (AcademicYear year in Years.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedInfo(year);
            foreach (string html in pageSources.Values)
            {
                InfoFetcher infoFetcher = new(html);
                InfoPage infoPage = new(infoFetcher);
                InfoPages.Add(year.Name, infoPage);
            }
        }
    }
}