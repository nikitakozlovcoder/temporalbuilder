
using TemporalBuilder.Builder.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class IfHandlerBuilder<T, TComplete>(T status, Func<bool> condition, WorkflowStatusBuilder<T, TComplete> workflowStatusBuilder) : IHandleInIfBuilder<T, TComplete> where T : Enum
{
    public IElseIfBuilder<T, TComplete> Handle(Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>> handler)
    {
        var wfHandler = new WorkflowHandler<T, TComplete>()
        {
            Condition = condition,
            Handler = handler
        };
        
        workflowStatusBuilder.AddHandler(status, wfHandler);
        return new ElseIfBuilder<T, TComplete>(status, workflowStatusBuilder);
    }
}