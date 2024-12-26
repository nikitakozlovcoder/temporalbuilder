using TemporalBuilder.Builder.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowCompleteBuilder<TComplete> : IWithStatusBuilder<TComplete>
{
    public IInBuilder<T, TComplete> WithStatus<T>(T status) where T : Enum
    {
      return new WorkflowStatusBuilder<T, TComplete>(status);
    }
}
