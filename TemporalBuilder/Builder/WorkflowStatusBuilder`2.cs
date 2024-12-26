using System.Collections.Immutable;
using TemporalBuilder.Builder.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.Controller;
using TemporalBuilder.Builder.Controller.Contracts;
using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowStatusBuilder<T, TComplete>(T initialStatus) : IInBuilder<T, TComplete> where T : Enum
{
    private readonly Dictionary<T, List<WorkflowHandler<T, TComplete>>> _handlers = new();

    public IIfBuilder<T, TComplete> In(T status)
    {
        var handler = new WorkflowHandler<T, TComplete>(status, this);
        var containsKey = _handlers.ContainsKey(status);
        if (containsKey)
        {
            _handlers[status].Add(handler);
        }
        else
        {
            _handlers.Add(status, [handler]);
        }

        return handler;
    }

    public IWorkflowController<T, TComplete> Build()
    {
        return new WorkflowController<T, TComplete>(
            _handlers.ToDictionary(pair => pair.Key, pair => pair.Value.ToImmutableList()),
            initialStatus);
    }
}