namespace TemporalBuilder.Builder.Controller.Contracts;

public interface IWorkflowController<T, TComplete> where T : Enum
{
    T Status { get; }
    SignalControllerBuilder<T> Signal { get; }
    Task<TComplete> RunAsync();
}