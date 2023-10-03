

namespace CourseProject;

public interface IEvalFetcher
{
    string ID { get; }
    string Name { get; }
    string Term { get; }
    int CouldRespond { get; }
    int DidRespond { get; }
    int ShouldNotRespond { get; }
    string LastUpdated { get; }
    List<Eval> EvalList { get; }
    int EvalWebsiteUrlNumber { get; }
}

public class EvalFetcher : IEvalFetcher
{
    private string PageSource { get; }
    public string ID { get; }
    public string Name { get; }
    public string Term { get; }
    public int CouldRespond { get; }
    public int DidRespond { get; }
    public int ShouldNotRespond { get; }
    public string LastUpdated { get; }
    public List<Eval> EvalList { get; }
    public int EvalWebsiteUrlNumber { get; }

    public EvalFetcher(string html)
    {
        PageSource = html;
        ID = ParseID();
        Name = ParseName();
        Term = ParseTerm();
        CouldRespond = ParseCouldRespond();
        DidRespond = ParseDidRespond();
        ShouldNotRespond = ParseShouldNotRespond();
        LastUpdated = ParseLastUpdated();
        EvalList = ParseEvalList();
        EvalWebsiteUrlNumber = 0;
    }

    public static readonly Dictionary<Eval.EvalType, string> DtuWebsiteEvalNames = new()
    {
        { Eval.EvalType.LearnedMuch, "1.1" },
        { Eval.EvalType.LearningObjectives, "1.2" },
        { Eval.EvalType.MotivatingActivities, "1.3" },
        { Eval.EvalType.OppertunityForFeedback, "1.4" },
        { Eval.EvalType.ClearExpectations, "1.5" },
        { Eval.EvalType.TimeSpentOnCourse, "2.1" },
    };

    public static readonly Dictionary<LegacyEval.LegacyEvalType, string> DtuWebsiteLegacyEvalNames = new()
    {
        { LegacyEval.LegacyEvalType.LearnedMuch, "1" },
        { LegacyEval.LegacyEvalType.EncouragedToParticipate, "2" },
        { LegacyEval.LegacyEvalType.MotivatingActivities, "3" },
        { LegacyEval.LegacyEvalType.OppertunityForFeedback, "4" },
        { LegacyEval.LegacyEvalType.ActivityContinuity, "5" },
        { LegacyEval.LegacyEvalType.TimeSpentOnCourse, "6" },
        { LegacyEval.LegacyEvalType.PrerequisiteLevel, "7" },
        { LegacyEval.LegacyEvalType.GenerallyGoodCourse, "8" },
        { LegacyEval.LegacyEvalType.PromptedToEvaluate, "9" },
    };

    private string ParseID()
    {
        string start = "Resultater : ";
        string middle = "([a-zA-Z0-9]{5})";
        string end = " .*";
        string pattern = $"{start}{middle}{end}";

        return PatternMatcher.Get(pattern, PageSource, 1);
    }

    private string ParseName()
    {
        string start = "Resultater : [A-Z0-9]{5} ";
        string middle = "(.*?) ";
        string end = "[A-Z]\\d{2}";
        string pattern = $"{start}{middle}{end}";

        return PatternMatcher.Get(pattern, PageSource, 1);
    }

    private string ParseTerm()
    {
        string start = "Resultater : [A-Z0-9]{5} .* ";
        string middle = "([A-Z]\\d{2})";
        string end = "";
        string pattern = $"{start}{middle}{end}";

        return PatternMatcher.Get(pattern, PageSource, 1);
    }

    private int ParseCouldRespond()
    {
        string start = "svarprocent \\d+ / \\(";
        string middle = "(\\d+)";
        string end = " - \\d+\\)";
        string pattern = $"{start}{middle}{end}";
        string valueStr = PatternMatcher.Get(pattern, PageSource, 1);
        return PatternMatcher.ConvertToInt(valueStr);
    }

    private int ParseDidRespond()
    {
        string start = "svarprocent ";
        string middle = "(\\d+)";
        string end = " / \\(\\d+ - \\d+\\)";
        string pattern = $"{start}{middle}{end}";
        string valueStr = PatternMatcher.Get(pattern, PageSource, 1);
        return PatternMatcher.ConvertToInt(valueStr);
    }

    private int ParseShouldNotRespond()
    {
        string start = "svarprocent \\d+ / \\(\\d+ - ";
        string middle = "(\\d+)";
        string end = "\\)";
        string pattern = $"{start}{middle}{end}";
        string valueStr = PatternMatcher.Get(pattern, PageSource, 1);
        return PatternMatcher.ConvertToInt(valueStr);
    }

    private string ParseLastUpdated()
    {
        string start = "Opdateret\\s+&#32;den &#32;";
        string middle = "(\\d+\\.\\s+\\w+\\s+\\d+)";
        string end = "";
        string pattern = $"{start}{middle}{end}";
        return PatternMatcher.Get(pattern, PageSource, 1);
    }

    private List<Eval> ParseEvalList()
    {
        List<Eval> evalList = new();
        foreach (var evalType in DtuWebsiteEvalNames)
        {
            Eval eval = Eval.CreateEval(evalType.Key);
            eval.Responses = ParseQuestion(evalType.Value);
            evalList.Add(eval);
        }
        if (evalList.Count == 0)
        {
            return ParseLegacyEvalList();
        }
        return evalList;
    }

    private List<Eval> ParseLegacyEvalList()
    {
        List<Eval> evalList = new();
        foreach (var evalType in DtuWebsiteLegacyEvalNames)
        {
            Eval eval = LegacyEval.CreateEval(evalType.Key);
            eval.Responses = ParseQuestion(evalType.Value);
            evalList.Add(eval);
        }
        return evalList;
    }

    private Dictionary<string, int> ParseQuestion(string questionIndex)
    {
        Dictionary<string, int> questionResponses = new();
        string slicedPageSource = IsolateQuestionSection(questionIndex, PageSource);
        AddOptionsToDict(questionResponses, slicedPageSource);
        return questionResponses;
    }

    private static string IsolateQuestionSection(string questionIndex, string html)
    {
        string start = $"<div class=\"FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright\">{questionIndex}</div>";
        string middle = "(.*?)";
        string end = "<div class=\"CourseSchemaResultFooter grid_6 clearmarg \">";
        string pattern = $"{start}{middle}{end}";
        return PatternMatcher.Get(pattern, html, 1);
    }

    private static void AddOptionsToDict(Dictionary<string, int> result, string slicedHtml)
    {
        string start = "<div class=\"FinalEvaluation_Result_OptionColumn grid_1 clearmarg\">";
        string middle = "(.*?)";
        string end = "</div>.*?<span>(\\d+)</span>";
        string pattern = $"{start}{middle}{end}";
        Dictionary<string, string> answers = PatternMatcher.GetDict(pattern, slicedHtml);
        string mostRecentKey = "";
        int count = 0;
        foreach (var kvp in answers)
        {
            count++;
            string key = kvp.Key;
            if (key.Length == 0)
            {
                key = FixLegacyEvalAnswers(count, mostRecentKey);
            }
            else
            {
                mostRecentKey = key;
            }
            int value = PatternMatcher.ConvertToInt(kvp.Value);
            result.Add(key, value);
        }
    }

    private static string FixLegacyEvalAnswers(int iteration, string firstKey)
    // In evaluations from F2019 and earlier, response option 2, 3 and 4 is blank
    {
        if (iteration == 2)
        {
            if (firstKey == "Helt enig")
            {
                return "Enig";
            }
            else if (firstKey == "Meget mindre")
            {
                return "Mindre";
            }
            else if (firstKey == "For lave")
            {
                return "Lave";
            }
        }
        else if (iteration == 3)
        {
            return "Hverken eller";
        }
        else if (iteration == 4)
        {
            if (firstKey == "Helt enig")
            {
                return "Unig";
            }
            else if (firstKey == "Meget mindre")
            {
                return "St&#248;rre";
            }
            else if (firstKey == "For h&#248;je")
            {
                return "H&#248;je";
            }
        }
        Console.WriteLine("Warning: Unknown evaluation response key");
        return $"{PatternMatcher.PatternNotFound}{iteration}";
    }
}