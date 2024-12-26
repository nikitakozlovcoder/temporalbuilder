using System.Collections.Immutable;
using TemporalBuilder.Builder.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.Controller;
using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowStatusBuilder<T, TComplete>(T initialStatus) : IInBuilder<T, TComplete> where T : Enum
{
    private readonly Dictionary<T, List<WorkflowHandler<T, TComplete>>> _handlers = new();

    public void AddHandler(T status, WorkflowHandler<T, TComplete> handler)
    {
        var exists = _handlers.ContainsKey(status);
        if (exists)
        {
            _handlers[status].Add(handler);
            return;
        }
        
        _handlers.Add(status, [handler]);
    }

    public IHandleOrIfBuilder<T, TComplete> In(T status)
    {
        return new InBuilder<T, TComplete>(status, this);
    }

    public IWorkflowController<T, TComplete> Build()
    {
        return new WorkflowController<T, TComplete>(
            _handlers.ToDictionary(pair => pair.Key, pair => pair.Value.ToImmutableList()),
            initialStatus);
    }
}