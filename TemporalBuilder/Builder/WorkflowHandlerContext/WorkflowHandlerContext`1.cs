using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

namespace TemporalBuilder.Builder.WorkflowHandlerContext;

public record WorkflowHandlerContext<T> : IWorkflowHandlerContextPendable<T> where T : Enum
{
    public T? HasStatus { get; set; }
    public IReadOnlyCollection<T>? PendingStatuses { get; set; }
    public required WorkflowHandlerContextBuilder<T> Builder { get; init; }
    public IWorkflowHandlerContext<T> Pending()
    {
        return Builder.Pending([], this);
    }

    public IWorkflowHandlerContext<T> Pending(T status)
    {
        return Builder.Pending([status], this);
    }

    public IWorkflowHandlerContext<T> Pending(IReadOnlyCollection<T> statuses)
    {
        return Builder.Pending(statuses, this);
    }
}