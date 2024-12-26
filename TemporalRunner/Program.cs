using TemporalBuilder.Workflows;
using Temporalio.Client;
using Temporalio.Worker;

var client = await TemporalClient.ConnectAsync(new TemporalClientConnectOptions("localhost:7233"));

using var worker = new TemporalWorker(
    client,
    new TemporalWorkerOptions("my-task-queue").AddWorkflow<HelloWordWorkflow>());

var w =  worker.ExecuteAsync(default);

var handle = await client.StartWorkflowAsync(
    (HelloWordWorkflow wf) => wf.RunAsync(),
    new WorkflowOptions(id: "my-workflow-id", taskQueue: "my-task-queue"));

await handle.SignalAsync(wf => wf.CompleteWithGreetingAsync());
Console.WriteLine("Signaled!");

var result = await handle.GetResultAsync();
await w;