

namespace CourseProject;

public interface IEvalParser
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