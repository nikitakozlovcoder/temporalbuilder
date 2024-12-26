using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts;

namespace TemporalBuilder.Builder.Contracts;

public interface IHandleBuilder<T, TComplete> where T : Enum
{
    IInBuilder<T, TComplete> Handle(Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>> handler);
}