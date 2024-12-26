using TemporalBuilder.Builder.WorkflowHandlerContext.Contracts.WithCompleteValue;

namespace TemporalBuilder.Builder;

public class WorkflowHandler<T, TComplete>()
    where T : Enum
{
    public Func<bool> Condition { get; set; } = () => true;
    public Func<IWorkflowHandlerContextBuilder<T, TComplete>, IWorkflowHandlerContext<T, TComplete>>? Handler { get; set; }
}