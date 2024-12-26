using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalControllerBuilder<T>(IWorkflowControllerSettableStatus<T> workflowController)
    : ISignalControllerHandleBuilder<T> where T : Enum
{
    public void Handle(Func<T> handler)
    {
        var signalController = new SignalController<T>
        {
            WorkflowController = workflowController
        };

        signalController.Handle(handler);
    }

    public SignalControllerIfHandlerBuilder<T> If(Func<bool> condition)
    {
        return new SignalControllerIfHandlerBuilder<T>(condition, workflowController);
    }
}