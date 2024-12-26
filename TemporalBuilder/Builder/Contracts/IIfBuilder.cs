namespace TemporalBuilder.Builder.Contracts;

public interface IIfBuilder<T, TComplete> where T : Enum
{
    IHandleInIfBuilder<T, TComplete> If(Func<bool> condition);
}