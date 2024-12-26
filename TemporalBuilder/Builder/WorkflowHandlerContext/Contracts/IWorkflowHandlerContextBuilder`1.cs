namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContextBuilder<T> : IWorkflowHandlerContextPending<T>, IWorkflowHandlerContextStatus<T>
    where T : Enum
{
    IWorkflowHandlerContext<T> Complete();
}