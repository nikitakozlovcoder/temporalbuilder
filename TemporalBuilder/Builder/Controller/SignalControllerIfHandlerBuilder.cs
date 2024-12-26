using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalControllerIfHandlerBuilder<T>(
    Func<bool> condition,
    IWorkflowControllerSettableStatus<T> workflowController) where T : Enum
{
    public SignalControllerElseIfBuilder<T> Handle(Func<T> handler)
    {
        var signalController = new SignalController<T>
        {
            WorkflowController = workflowController,
            Condition = condition
        };

        signalController.Handle(handler);
        return new SignalControllerElseIfBuilder<T>(workflowController);
    }
}