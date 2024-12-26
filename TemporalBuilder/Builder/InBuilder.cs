using TemporalBuilder.Builder.Contracts.WithCompleteValue;
using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class InBuilder<T, TComplete>(T status, WorkflowStatusBuilder<T, TComplete> workflowStatusBuilder)
    : IHandleOrIfBuilder<T, TComplete> where T : Enum
{
    public IInBuilder<T, TComplete> Handle(Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>> handler)
    {
        var wfHandler = new WorkflowHandler<T, TComplete>()
        {
            Handler = handler
        };
        
        workflowStatusBuilder.AddHandler(status, wfHandler);
        return workflowStatusBuilder;
    }

    public IHandleInIfBuilder<T, TComplete> If(Func<bool> condition)
    {
        return new IfHandlerBuilder<T, TComplete>(status, condition, workflowStatusBuilder);
    }
}