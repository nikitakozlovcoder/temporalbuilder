namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IElseBuilder<T, TComplete> : IInBuilder<T, TComplete> where T : Enum
{
    IHandleBuilder<T, TComplete> Else();
}