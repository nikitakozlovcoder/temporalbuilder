namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

public interface IWorkflowHandlerContextBuilder<T, TComplete> : IWorkflowHandlerContextPending<T, TComplete>, IWorkflowHandlerContextStatus<T, TComplete>
    where T : Enum
{
    IWorkflowHandlerContext<T, TComplete> Complete(TComplete value);
}