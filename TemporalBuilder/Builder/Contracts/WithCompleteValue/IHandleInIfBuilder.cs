using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IHandleInIfBuilder<T, TComplete> where T : Enum
{
    IElseIfBuilder<T, TComplete> Handle(Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>> handler);
}