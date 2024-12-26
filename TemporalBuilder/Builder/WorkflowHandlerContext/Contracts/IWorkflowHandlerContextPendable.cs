using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContextPendable<T, TComplete> : 
    IWorkflowHandlerContext<T, TComplete>,
    IWorkflowHandlerContextPending<T, TComplete>
    where T : Enum;