using TemporalBuilder.Builder.Contracts;
using TemporalBuilder.Builder.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowBuilder : IWorkflowBuilder
{
    public IWithStatusBuilder<TComplete> WithComplete<TComplete>()
    {
        return new WorkflowCompleteBuilder<TComplete>();
    }
}