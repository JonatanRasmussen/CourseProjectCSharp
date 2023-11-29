

namespace CourseProject;

public class EvalResponseRate
{
    public int CouldRespond { get; }
    public int DidRespond { get; }
    public int ShouldNotRespond { get; }

    public EvalResponseRate(int couldRespond, int didRespond, int shouldNotRespond)
    {
        CouldRespond = couldRespond;
        DidRespond = didRespond;
        ShouldNotRespond = shouldNotRespond;
    }

    public static EvalResponseRate CreateEmpty()
    {
        int couldRespond = -1;
        int didRespond = -1;
        int shouldNotRespond = -1;
        return new EvalResponseRate(couldRespond, didRespond, shouldNotRespond);
    }
}