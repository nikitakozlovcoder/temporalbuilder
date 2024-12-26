using TemporalBuilder.Builder.Contracts;
using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder;

public class ElseIfBuilder<T, TComplete>(T status, WorkflowStatusBuilder<T, TComplete> workflowStatusBuilder)
    : IElseIfBuilder<T, TComplete> where T : Enum
{
    public IHandleOrIfBuilder<T, TComplete> In(T status)
    {
        return workflowStatusBuilder.In(status);
    }

    public IWorkflowController<T, TComplete> Build()
    {
        return workflowStatusBuilder.Build();
    }

    public IHandleBuilder<T, TComplete> Else()
    {
        return new InBuilder<T, TComplete>(status, workflowStatusBuilder);
    }

    public IHandleInIfBuilder<T, TComplete> ElseIf(Func<bool> condition)
    {
        return new IfHandlerBuilder<T, TComplete>(status, condition, workflowStatusBuilder);
    }
}