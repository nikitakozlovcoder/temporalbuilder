using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;
using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.WorkflowHandlerContext;

public class WorkflowHandlerContextBuilder<T, TComplete> : IWorkflowHandlerContextBuilder<T, TComplete> where T : Enum
{
    public IWorkflowHandlerContext<T, TComplete> Pending()
    {
        return Pending([]);
    }

    public IWorkflowHandlerContext<T, TComplete> Pending(T status)
    {
        return Pending([status]);
    }

    public IWorkflowHandlerContext<T, TComplete> Pending(IReadOnlyCollection<T> status)
    {
        return new WorkflowHandlerContext<T, TComplete>
        {
            Builder = this,
            PendingStatuses = status
        };
    }
    
    public IWorkflowHandlerContext<T, TComplete> Pending(IReadOnlyCollection<T> statuses, WorkflowHandlerContext<T, TComplete> ctx)
    {
       return ctx with { PendingStatuses = statuses };
    }

    public IWorkflowHandlerContextPendable<T, TComplete> ToStatus(T status)
    {
        return new WorkflowHandlerContext<T, TComplete>
        {
            Builder = this,
            ToStatus = status
        };
    }

    public IWorkflowHandlerContext<T, TComplete> Complete(TComplete complete)
    {
        return new WorkflowHandlerContext<T, TComplete>
        {
            Builder = this,
            Completed = true,
            CompleteValue  = complete
        };
    }
}