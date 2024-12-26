namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IIfBuilder<T, TComplete> : IHandleBuilder<T, TComplete> where T : Enum
{
    IHandleBuilder<T, TComplete> If(Func<bool> condition);
}