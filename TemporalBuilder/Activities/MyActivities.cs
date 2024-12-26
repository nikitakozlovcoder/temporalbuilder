using Temporalio.Activities;

namespace TemporalBuilder.Activities;

public class MyActivities
{
    // Activities can be async and/or static too! We just demonstrate instance
    // methods since many will use them that way.
    [Activity]
    public string SayHello(string name) => $"Hello, {name}!";
}