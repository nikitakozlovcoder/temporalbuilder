using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalControllerBuilder<T>(IWorkflowControllerSettableStatus<T> workflowController) : ISignalControllerIfBuilder<T> where T : Enum
{
    public ISignalControllerIfBuilder<T> Handle(Func<T> handler)
    {
        var controller = new SignalController<T>
        {
            SignalBuilder = this,
            WorkflowController = workflowController
        };
        
        controller.Handle(handler);
        return this;
    }

    public ISignalControllerHandle<T> If(Func<bool> condition)
    {
        return new SignalController<T>
        {
            SignalBuilder = this,
            Condition = condition,
            WorkflowController = workflowController
        };
    }
}