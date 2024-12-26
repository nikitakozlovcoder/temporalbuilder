using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

namespace TemporalBuilder.Builder.WorkflowHandlerContext;

public class WorkflowHandlerContextBuilder<T> : IWorkflowHandlerContextBuilder<T> where T : Enum
{
    public IWorkflowHandlerContext<T> Pending()
    {
        return Pending([]);
    }

    public IWorkflowHandlerContext<T> Pending(T status)
    {
        return Pending([status]);
    }

    public IWorkflowHandlerContext<T> Pending(IReadOnlyCollection<T> status)
    {
        return new WorkflowHandlerContext<T>
        {
            Builder = this,
            PendingStatuses = status
        };
    }
    
    public IWorkflowHandlerContext<T> Pending(IReadOnlyCollection<T> statuses, WorkflowHandlerContext<T> ctx)
    {
       return ctx with { PendingStatuses = statuses };
    }

    public IWorkflowHandlerContextPendable<T> ToStatus(T status)
    {
        return new WorkflowHandlerContext<T>
        {
            Builder = this,
            HasStatus = status
        };
    }

    public IWorkflowHandlerContext<T> Complete()
    {
        return new WorkflowHandlerContext<T>
        {
            Builder = this
        };
    }
}