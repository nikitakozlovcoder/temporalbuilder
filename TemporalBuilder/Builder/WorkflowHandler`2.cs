using TemporalBuilder.Builder.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowHandler<T, TComplete>(T state, WorkflowStatusBuilder<T, TComplete> workflowStatusBuilder) : IIfBuilder<T, TComplete> where T : Enum
{
    public T State { get; } = state;
    public Func<bool> Condition { get; set; } = () => true;
    public Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>>? Handler { get; set; }
    
    public IInBuilder<T, TComplete> Handle(Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>> handler)
    {
        Handler = handler;
        return workflowStatusBuilder;
    }
    
    public IHandleBuilder<T, TComplete> If(Func<bool> condition)
    {
        Condition = condition;
        return this;
    }
}