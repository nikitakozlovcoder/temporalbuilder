using TemporalBuilder.Builder;
using TemporalBuilder.Builder.Controller.Contracts.WithCompleteValue;
using Temporalio.Workflows;

namespace TemporalBuilder.Workflows;

[Workflow]
public class HelloWordWorkflow
{
    private IWorkflowController<HelloWorldState, string>? _controller;
    
    [WorkflowRun]
    public async Task<string> RunAsync()
    { 
       _controller = new WorkflowBuilder()
            .WithComplete<string>()
            .WithStatus(HelloWorldState.Start)
            .In(HelloWorldState.Start).Handle(ctx => ctx.Pending(HelloWorldState.MyState))
            .In(HelloWorldState.MyState).Handle(ctx => ctx.Complete("Hello, World!"))
            .Build();

        return await _controller.RunAsync();
    }

    [WorkflowSignal]
    public Task CompleteWithGreetingAsync()
    {
         _controller!.Signal.If(() => true).Handle(() => HelloWorldState.MyState);
         return Task.CompletedTask;
    }
}