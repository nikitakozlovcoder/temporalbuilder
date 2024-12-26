namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IIfBuilder<T, TComplete> where T : Enum
{
    IHandleInIfBuilder<T, TComplete> If(Func<bool> condition);
}