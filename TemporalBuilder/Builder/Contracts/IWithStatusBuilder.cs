namespace TemporalBuilder.Builder.Contracts;

public interface IWithStatusBuilder<TComplete>
{
    IInBuilder<T, TComplete> WithStatus<T>(T status) where T : Enum;
}