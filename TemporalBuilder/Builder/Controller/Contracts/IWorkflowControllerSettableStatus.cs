namespace TemporalBuilder.Builder.Controller.Contracts;

public interface IWorkflowControllerSettableStatus<T> where T : Enum
{
    public T Status { set; }
}