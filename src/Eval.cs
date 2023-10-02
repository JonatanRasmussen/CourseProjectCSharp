

namespace CourseProject;

public class Eval
{
    public static readonly string Q11 = "Question 1.1: I have learned a lot from this course.";
    public static readonly string Q12 = "Question 1.2: The learning activities of the course were in line with the learning objectives of the course.";
    public static readonly string Q13 = "Question 1.3: The learning activities motivated me to work with the material.";
    public static readonly string Q14 = "Question 1.4: During the course, I have had the opportunity to get feedback on my performance.";
    public static readonly string Q15 = "Question 1.5: It was generally clear what was expected of me in exercises, project work, etc.";
    public static readonly string Q21 = "Question 2.1: 5 ECTS credits correspond to nine working hours per week for the 13-week period (45 working hours per week for the three-week period). I think the time I have spent on this course is...";
    public static readonly Dictionary<string, int> UndefinedResponse = new();
    public enum EvalType // Used from E2019 and onward
    {
        LearnedMuch,
        LearningObjectives,
        MotivatingActivities,
        OppertunityForFeedback,
        ClearExpectations,
        TimeSpentOnCourse,
    }
    public enum AnswerType
    {
        AgreeDisagree,
        MoreLess,
        LegacyLowHigh,
        LegacyMoreLess,
        LegacyYesNo,
    }
    private static readonly Dictionary<EvalType, (string, string, AnswerType)> EvalConfig = new()
    {
        { EvalType.LearnedMuch, ("Q11", Q11, AnswerType.AgreeDisagree) },
        { EvalType.LearningObjectives, ("Q12", Q12, AnswerType.AgreeDisagree) },
        { EvalType.MotivatingActivities, ("Q13", Q13, AnswerType.AgreeDisagree) },
        { EvalType.OppertunityForFeedback, ("Q14", Q14, AnswerType.AgreeDisagree) },
        { EvalType.ClearExpectations, ("Q15", Q15, AnswerType.AgreeDisagree) },
        { EvalType.TimeSpentOnCourse, ("Q21", Q21, AnswerType.MoreLess) },
    };

    public string Name { get; }
    public string Question { get; }
    public AnswerType AnswerOptions { get; }
    public Dictionary<string, int> Responses { get; set; }

    protected Eval(string name, string question, AnswerType answerOptions)
    {
        Name = name;
        Question = question;
        AnswerOptions = answerOptions;
        Responses = UndefinedResponse;
    }

    public static Eval CreateEval(EvalType evalType)
    {
        var (name, question, answerOptions) = EvalConfig[evalType];
        return new Eval(name, question, answerOptions);
    }
}

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