namespace TemporalBuilder.Builder.Contracts;

public interface IElseIfBuilder<T, TComplete> : IElseBuilder<T, TComplete> where T : Enum
{
    IHandleInIfBuilder<T, TComplete> ElseIf(Func<bool> condition);
}