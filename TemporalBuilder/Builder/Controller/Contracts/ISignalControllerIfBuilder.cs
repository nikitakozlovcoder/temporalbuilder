namespace TemporalBuilder.Builder.Controller.Contracts;

public interface ISignalControllerIfBuilder<T> : ISignalControllerBuilder<T> where T : Enum
{
    ISignalControllerHandle<T> If(Func<bool> condition);
}