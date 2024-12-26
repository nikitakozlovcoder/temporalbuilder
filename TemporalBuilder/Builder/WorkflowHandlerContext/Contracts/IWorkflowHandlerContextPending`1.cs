namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContextPending<T> where T : Enum
{
    IWorkflowHandlerContext<T> Pending();
    IWorkflowHandlerContext<T> Pending(T status);
    IWorkflowHandlerContext<T> Pending(IReadOnlyCollection<T> statuses);
}