using System.Collections.Immutable;
using TemporalBuilder.Builder.Controller.Contracts;
using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.WorkflowHandlerContext;
using Temporalio.Workflows;

namespace TemporalBuilder.Builder.Controller;

public class WorkflowController<T, TComplete>(
    IReadOnlyDictionary<T, ImmutableList<WorkflowHandler<T, TComplete>>> handlers,
    T initialStatus) : IWorkflowControllerSettableStatus<T>, IWorkflowController<T, TComplete> where T : Enum
{
    public T Status { get; set; } = initialStatus;
    public ISignalControllerIfBuilder<T> Signal => new SignalControllerBuilder<T>(this);

    public async Task<TComplete> RunAsync()
    {
        while (true)
        {
            var handler = FindHandler();
            var ctxBuilder = new WorkflowHandlerContextBuilder<T, TComplete>();
            var ctx = handler.Handler!.Invoke(ctxBuilder);
            if (ctx.Completed)
            {
                return ctx.CompleteValue!;
            }

            if (ctx.ToStatus != null)
            {
                Status = ctx.ToStatus;
            }

            if (ctx.PendingStatuses is not null)
            {
                await PendingAsync(ctx.PendingStatuses, Status);
            }
        }
    }

    private async Task PendingAsync(IReadOnlyCollection<T> pending, T curStatus)
    {
        if (!pending.Any())
        {
            await Workflow.WaitConditionAsync(() => Status.CompareTo(curStatus) != 0);
            return;
        }

        await Workflow.WaitConditionAsync(() => pending.Any(x => Status.CompareTo(x) == 0));
    }

    private WorkflowHandler<T, TComplete> FindHandler()
    {
        var existsStatus = handlers.ContainsKey(Status);
        if (!existsStatus)
        {
            throw new Temporalio.Exceptions.ApplicationFailureException("Workflow handler not found");
        }

        var handler = handlers[Status].FirstOrDefault(handler => handler.Condition());
        if (handler is null)
        {
            throw new Temporalio.Exceptions.ApplicationFailureException("Workflow handler not found");
        }

        return handler;
    }
}