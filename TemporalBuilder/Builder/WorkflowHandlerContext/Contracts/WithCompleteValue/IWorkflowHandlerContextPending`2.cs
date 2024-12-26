namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

public interface IWorkflowHandlerContextPending<T, TComplete> where T : Enum
{
    IWorkflowHandlerContext<T, TComplete> Pending();
    IWorkflowHandlerContext<T, TComplete> Pending(T status);
    IWorkflowHandlerContext<T, TComplete> Pending(IReadOnlyCollection<T> statuses);
}