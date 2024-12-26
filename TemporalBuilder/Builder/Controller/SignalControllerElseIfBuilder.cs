using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Controller;

public class SignalControllerElseIfBuilder<T>(IWorkflowControllerSettableStatus<T> workflowController) where T : Enum
{
    public SignalControllerIfHandlerBuilder<T> ElseIf(Func<bool> condition)
    {
        return new SignalControllerIfHandlerBuilder<T>(condition, workflowController);
    }
    
    public ISignalControllerHandleBuilder<T> Else()
    {
        return new SignalControllerBuilder<T>(workflowController);
    }
}