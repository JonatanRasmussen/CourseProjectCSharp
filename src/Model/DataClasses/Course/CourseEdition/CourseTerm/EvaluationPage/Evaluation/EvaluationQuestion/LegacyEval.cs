

namespace CourseProject;

public class LegacyEval : Eval
{
    public static readonly string Q1 = "Question 1: I think I am learning a lot in this course.";
    public static readonly string Q2 = "Question 2. I think the teaching method encourages my active participation.";
    public static readonly string Q3 = "Question 3: I think the teaching material is good.";
    public static readonly string Q4 = "Question 4: I think that throughout the course, the teacher/s have clearly communicated to me where I stand academically.";
    public static readonly string Q5 = "Question 5: I think the teacher/s create/s good continuity between the different teaching activities.";
    public static readonly string Q6 = "Question 6: 5 points is equivalent to 9 hrs./week (45 hrs./week in the three-week period). I think my performance during the course is...";
    public static readonly string Q7 = "Question 7: I think the course description's prerequisites are...";
    public static readonly string Q8 = "Question 8: In general, I think this is a good course.";
    public static readonly string Q9 = "Question 9: During the course, have you been asked to evaluate the course and the teaching, for example through an oral or written mid-term evaluation?";
    public enum LegacyEvalType // Used from E2019 and onward
    {
        LearnedMuch,
        EncouragedToParticipate,
        MotivatingActivities,
        OppertunityForFeedback,
        ActivityContinuity,
        TimeSpentOnCourse,
        PrerequisiteLevel,
        GenerallyGoodCourse,
        PromptedToEvaluate,
    }
    private static readonly Dictionary<LegacyEvalType, (string, string, AnswerType)> LegacyEvalConfig = new()
    {
        { LegacyEvalType.LearnedMuch, ("Q1", Q1, AnswerType.AgreeDisagree) },
        { LegacyEvalType.EncouragedToParticipate, ("Q2", Q2, AnswerType.AgreeDisagree) },
        { LegacyEvalType.MotivatingActivities, ("Q3", Q3, AnswerType.AgreeDisagree) },
        { LegacyEvalType.OppertunityForFeedback, ("Q4", Q4, AnswerType.AgreeDisagree) },
        { LegacyEvalType.ActivityContinuity, ("Q5", Q5, AnswerType.AgreeDisagree) },
        { LegacyEvalType.TimeSpentOnCourse, ("Q6", Q6, AnswerType.LegacyMoreLess) },
        { LegacyEvalType.PrerequisiteLevel, ("Q7", Q7, AnswerType.LegacyLowHigh) },
        { LegacyEvalType.GenerallyGoodCourse, ("Q8", Q8, AnswerType.AgreeDisagree) },
        { LegacyEvalType.PromptedToEvaluate, ("Q9", Q9, AnswerType.LegacyYesNo) },
    };

    protected LegacyEval(string name, string question, AnswerType answerOptions) : base(name, question, answerOptions)
    {
    }

    public static Eval CreateEval(LegacyEvalType evalType)
    {
        var (name, question, answerOptions) = LegacyEvalConfig[evalType];
        return new LegacyEval(name, question, answerOptions);
    }
}