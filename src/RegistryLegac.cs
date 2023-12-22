

namespace CourseProject;

public class RegistryLegac
{

    public Dictionary<string, EvalPage> EvalPages { get; set; }
    public Dictionary<string, GradePage> GradePages { get; set; }
    public Dictionary<string, InfoPage> InfoPages { get; set; }
    public Dictionary<string, AnotherLegacyTerm> Terms { get; set; }
    public Dictionary<string, LegacyAcademicYear> Years { get; set; }

    public RegistryLegac()
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
        foreach (AnotherLegacyTerm term in Terms.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedEvals(term);
            foreach (string html in pageSources.Values)
            {
                EvalParser evalFetcher = new(html);
                EvalPage evalPage = new(evalFetcher);
                EvalPages.Add(term.Name, evalPage);
            }
        }
    }

    private void FillGradeRegistry()
    {
        foreach (AnotherLegacyTerm term in Terms.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedGrades(term);
            foreach (string html in pageSources.Values)
            {
                GradeParser gradeFetcher = new(html);
                GradePage gradePage = new(gradeFetcher);
                GradePages.Add(term.Name, gradePage);
            }
        }
    }

    private void FillInfoRegistry()
    {
        foreach (LegacyAcademicYear year in Years.Values)
        {
            Dictionary<string,string> pageSources = Persistence.ScrapedInfo(year);
            foreach (string html in pageSources.Values)
            {
                InfoParser infoFetcher = new(html);
                InfoPage infoPage = new(infoFetcher);
                InfoPages.Add(year.Name, infoPage);
            }
        }
    }
}