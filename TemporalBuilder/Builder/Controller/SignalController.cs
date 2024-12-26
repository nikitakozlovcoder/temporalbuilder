using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalController<T> where T : Enum
{
    public Func<bool> Condition { get; set; } = () => true;
    public required IWorkflowControllerSettableStatus<T> WorkflowController { get; init; }

    public void Handle(Func<T> handler)
    {
        if (!Condition())
        {
            return;
        }
        
        var status = handler();
        WorkflowController.Status = status;
    }
}