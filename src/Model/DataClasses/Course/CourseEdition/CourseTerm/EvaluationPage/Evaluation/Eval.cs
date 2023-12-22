

namespace CourseProject;

public class Eval
{
    public string QuestionNumber { get; }
    public string QuestionPrompt { get; }
    public EvalAnswerType AnswerType { get; }
    private Dictionary<string, int> ResponseCount { get; }
    public int ResponseTypeVeryLow { get; }
    public int ResponseTypeLow { get; }
    public int ResponseTypeMiddle { get; }
    public int ResponseTypeHigh { get; }
    public int ResponseTypeVeryHigh { get; }

    public Eval(string name, string question, EvalAnswerType answerType, Dictionary<string, int> responseCounts)
    {
        QuestionNumber = name;
        QuestionPrompt = question;
        AnswerType = answerType;
        ResponseCount = responseCounts;
        ResponseTypeVeryLow = CountResponseType(EvalAnswerOptions.VeryLow);
        ResponseTypeLow = CountResponseType(EvalAnswerOptions.Low);
        ResponseTypeMiddle = CountResponseType(EvalAnswerOptions.Middle);
        ResponseTypeHigh = CountResponseType(EvalAnswerOptions.High);
        ResponseTypeVeryHigh = CountResponseType(EvalAnswerOptions.VeryHigh);
    }

    public static Eval FindQ1(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.LearnedMuch;
        var legacyQ = EvalLegacyQuestion.LearnedMuch;
        return FindQ(modernQ, legacyQ, evalList);
    }

    public static Eval FindQ2(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.LearningObjectives;
        var legacyQ = EvalLegacyQuestion.EmptyValue;
        return FindQ(modernQ, legacyQ, evalList);
    }

    public static Eval FindQ3(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.MotivatingActivities;
        var legacyQ = EvalLegacyQuestion.MotivatingActivities;
        return FindQ(modernQ, legacyQ, evalList);
    }

    public static Eval FindQ4(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.OppertunityForFeedback;
        var legacyQ = EvalLegacyQuestion.OppertunityForFeedback;
        return FindQ(modernQ, legacyQ, evalList);
    }

    public static Eval FindQ5(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.ClearExpectations;
        var legacyQ = EvalLegacyQuestion.EmptyValue;
        return FindQ(modernQ, legacyQ, evalList);
    }

    public static Eval FindQ6(List<Eval> evalList)
    {
        var modernQ = EvalQuestion.TimeSpentOnCourse;
        var legacyQ = EvalLegacyQuestion.TimeSpentOnCourse;
        return FindQ(modernQ, legacyQ, evalList);
    }

    private static Eval FindQ(EvalQuestion evalType, EvalLegacyQuestion legacyEvalType, List<Eval> evalList)
    {
        var modernQ = EvalFactory.CreateEval(evalType, new());
        var legacyQ = EvalFactory.CreateLegacyEval(legacyEvalType, new());
        foreach (Eval eval in evalList)
        {
            bool evalMatchesModernQ = eval.QuestionPrompt == modernQ.QuestionPrompt;
            bool evalMatchesLegacyQ = eval.QuestionPrompt == legacyQ.QuestionPrompt;
            if (evalMatchesModernQ || evalMatchesLegacyQ)
            {
                return eval;
            };
        }
        return EvalFactory.CreateEmpty();
    }

    private int CountResponseType(List<string> answerOptions)
    {
        if (ResponseCount.Count == 0 || ResponseCount.Count == 3)
        {
            return 0; // Count==0 case for Empty evals, Count==3 case for LegacyEval Q9
        }
        foreach (var answerOption in answerOptions)
        {
            if (ResponseCount.ContainsKey(answerOption))
            {
                return ResponseCount[answerOption];
            }
        }
        return -1; // This should never happen
    }
}