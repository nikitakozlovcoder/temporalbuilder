namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContextStatus<T> where T : Enum
{
    IWorkflowHandlerContextPendable<T> ToStatus(T status);
}