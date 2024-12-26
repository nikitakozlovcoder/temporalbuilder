namespace TemporalBuilder.Builder.Controller.Contracts;

public interface ISignalControllerBuilder<T> where T : Enum
{
    ISignalControllerIfBuilder<T> Handle(Func<T> handler);
}