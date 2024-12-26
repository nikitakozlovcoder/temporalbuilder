using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;
using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.WorkflowHandlerContext;

public record WorkflowHandlerContext<T, TComplete> : IWorkflowHandlerContextPendable<T, TComplete> where T : Enum
{
    public T? ToStatus { get; set; }
    public IReadOnlyCollection<T>? PendingStatuses { get; set; }
    public required WorkflowHandlerContextBuilder<T, TComplete> Builder { get; init; }
    public bool Completed { get; init; }
    public TComplete? CompleteValue { get; set; }

    public IWorkflowHandlerContext<T, TComplete> Pending()
    {
        return Builder.Pending([], this);
    }

    public IWorkflowHandlerContext<T, TComplete> Pending(T status)
    {
        return Builder.Pending([status], this);
    }

    public IWorkflowHandlerContext<T, TComplete> Pending(IReadOnlyCollection<T> statuses)
    {
        return Builder.Pending(statuses, this);
    }
}