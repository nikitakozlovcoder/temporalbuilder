namespace TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

public interface IWorkflowHandlerContextPendable<T> : 
    IWorkflowHandlerContext<T>,
    IWorkflowHandlerContextPending<T>
    where T : Enum;