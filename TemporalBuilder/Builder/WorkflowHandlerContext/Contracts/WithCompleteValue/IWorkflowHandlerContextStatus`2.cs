namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

public interface IWorkflowHandlerContextStatus<T, TComplete> where T : Enum
{
    IWorkflowHandlerContextPendable<T, TComplete> ToStatus(T status);
}