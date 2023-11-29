

namespace CourseProject;

public class Eval
{
    public string QuestionNumber { get; }
    public string QuestionPrompt { get; }
    public EvalAnswerType AnswerOptions { get; }
    public Dictionary<string, int> ResponseCount { get; set; }

    public Eval(string name, string question, EvalAnswerType answerOptions)
    {
        QuestionNumber = name;
        QuestionPrompt = question;
        AnswerOptions = answerOptions;
        ResponseCount = new();
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
        var legacyQ = EvalLegacyQuestion.ActivityContinuity; // Note to self: fix??
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
        var legacyQ = EvalLegacyQuestion.EncouragedToParticipate; // Note to self: fix??
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
        var modernQ = EvalFactory.CreateEval(evalType);
        var legacyQ = EvalFactory.CreateLegacyEval(legacyEvalType);
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

    public bool IsEmpty()
    {
        if (QuestionPrompt == EvalFactory.CreateEmpty().QuestionPrompt)
        {
            return true;
        }
        return false;
    }
}