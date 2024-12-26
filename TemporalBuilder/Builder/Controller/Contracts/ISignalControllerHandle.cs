namespace TemporalBuilder.Builder.Controller.Contracts;

public interface ISignalControllerHandle<T> where T : Enum
{
    ISignalControllerIfBuilder<T> Handle(Func<T> handler);
}