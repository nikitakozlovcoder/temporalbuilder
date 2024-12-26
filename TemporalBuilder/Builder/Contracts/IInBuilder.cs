using TemporalBuilder.Builder.Controller.Contracts;

namespace TemporalBuilder.Builder.Contracts;

public interface IInBuilder<T, TComplete> where T : Enum
{
    IHandleOrIfBuilder<T, TComplete> In(T status);
    IWorkflowController<T, TComplete> Build();
}