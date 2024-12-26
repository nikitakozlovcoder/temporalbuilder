namespace TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;

public interface IWorkflowController<T, TComplete> where T : Enum
{
    T Status { get; }
    ISignalControllerIfBuilder<T> Signal { get; }
    Task<TComplete> RunAsync();
}