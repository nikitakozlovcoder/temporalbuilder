using TemporalBuilder.Builder.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.Contracts;

public interface ICompleteBuilder
{
    IWithStatusBuilder<TComplete> WithComplete<TComplete>();
}