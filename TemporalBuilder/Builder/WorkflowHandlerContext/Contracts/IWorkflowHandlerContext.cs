namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContext<T, TComplete> where T : Enum
{
    T? ToStatus { get; }
    IReadOnlyCollection<T>? PendingStatuses { get; }
    bool Completed { get; }
    TComplete? CompleteValue { get; }
}