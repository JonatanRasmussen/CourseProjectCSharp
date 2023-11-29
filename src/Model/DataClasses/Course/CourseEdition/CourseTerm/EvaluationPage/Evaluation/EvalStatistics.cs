

namespace CourseProject;

public class EvalStatistics
{
    public Eval LearnedMuch { get; }
    public Eval LearningObjectives { get; }
    public Eval MotivatingActivities { get; }
    public Eval OppertunityForFeedback { get; }
    public Eval ClearExpectations { get; }
    public Eval TimeSpentOnCourse { get; }

    public EvalStatistics(List<Eval> evalList)
    {
        LearnedMuch = Eval.FindQ1(evalList);
        LearningObjectives = Eval.FindQ2(evalList);
        MotivatingActivities = Eval.FindQ3(evalList);
        OppertunityForFeedback = Eval.FindQ4(evalList);
        ClearExpectations = Eval.FindQ5(evalList);
        TimeSpentOnCourse = Eval.FindQ6(evalList);
    }

    public static EvalStatistics CreateEmpty()
    {
        List<Eval> emptyList = new();
        return new EvalStatistics(emptyList);
    }
}