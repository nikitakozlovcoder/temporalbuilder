using TemporalBuilder.Builder;
using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;
using Temporalio.Workflows;

namespace TemporalBuilder.Workflows;

[Workflow]
public class HelloWordWorkflow
{
    private IWorkflowController<HelloWorldState, string>? _controller;
    private int _data = 1;
    
    [WorkflowRun]
    public async Task<string> RunAsync()
    { 
        _controller = new WorkflowBuilder()
            .WithComplete<string>()
            .WithStatus(HelloWorldState.Start)
            .In(HelloWorldState.Start)
                .Handle(ctx => ctx.Pending(HelloWorldState.MyState))
            .In(HelloWorldState.MyState)
             .If(() => _data != 1).Handle(ctx => ctx.Complete("Hello, World!"))
             .Else().Handle(ctx => ctx.Complete("Goodbye, World!"))
            .Build();
        
        return await _controller.RunAsync();
    }

    [WorkflowSignal]
    public async Task CompleteWithGreetingAsync()
    {
        await Workflow.WaitConditionAsync(() => _controller is not null);
        _controller!.Signal.Handle(() => HelloWorldState.MyState);
    }
}