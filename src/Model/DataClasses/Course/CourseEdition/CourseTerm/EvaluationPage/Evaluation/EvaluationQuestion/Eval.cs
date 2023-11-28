

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