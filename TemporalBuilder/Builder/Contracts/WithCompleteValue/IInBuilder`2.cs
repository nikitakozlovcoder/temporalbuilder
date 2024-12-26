using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder.Contracts.WithCompleteValue;

public interface IInBuilder<T, TComplete> where T : Enum
{
    IIfBuilder<T, TComplete> In(T status);
    IWorkflowController<T, TComplete> Build();
}