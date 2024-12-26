namespace TemporalBuilder.Builder.Contracts;

public interface IElseBuilder<T, TComplete> where T : Enum
{
    IHandleBuilder<T, TComplete> Else();
}