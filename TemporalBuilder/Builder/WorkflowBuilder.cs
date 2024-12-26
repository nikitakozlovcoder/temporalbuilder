using TemporalBuilder.Builder.Contracts;

namespace TemporalBuilder.Builder;

public class WorkflowBuilder : IWorkflowBuilder
{
    public IWithStatusBuilder<TComplete> WithComplete<TComplete>()
    {
        return new WorkflowCompleteBuilder<TComplete>();
    }
}