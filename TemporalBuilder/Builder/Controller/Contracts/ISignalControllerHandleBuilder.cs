namespace TemporalBuilder.Builder.Controller.Contracts;

public interface ISignalControllerHandleBuilder<T> where T : Enum
{
    void Handle(Func<T> handler);
}