using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalController<T> : ISignalControllerHandle<T> where T : Enum
{
    public Func<bool> Condition { get; set; } = () => true;
    public required IWorkflowControllerSettableStatus<T> WorkflowController { get; init; }
    public required ISignalControllerIfBuilder<T> SignalBuilder { get; init; }

    public ISignalControllerIfBuilder<T> Handle(Func<T> handler)
    {
        if (!Condition())
        {
            return SignalBuilder;
        }
        
        var status = handler();
        WorkflowController.Status = status;
        return SignalBuilder;
    }
}