namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

public interface IWorkflowHandlerContextPendable<T, TComplete> : 
    IWorkflowHandlerContext<T, TComplete>,
    IWorkflowHandlerContextPending<T, TComplete>
    where T : Enum;