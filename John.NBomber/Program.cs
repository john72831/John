using NBomber.CSharp;
using NBomber.Http.CSharp;

//var scenario = Scenario.Create("hello_world_scenario",  async context =>
//{
//    var step1 = await Step.Run("login",  context, async () =>
//    {
//        await Task.Delay(1_000);
//        return Response.Ok();
//    });

//    var step2 = await Step.Run("open_home_page", context, async () =>
//    {
//        await Task.Delay(1_000);
//        return Response.Ok();
//    });

//    var step3 = await Step.Run("logout", context, async () =>
//    {
//        await Task.Delay(1_000);
//        return Response.Ok();
//    });

//    return Response.Ok();
//})
//    .WithoutWarmUp()
//    .WithLoadSimulations(Simulation.Inject(rate: 10, interval: TimeSpan.FromSeconds(1), during: TimeSpan.FromSeconds(30)));

//NBomberRunner.RegisterScenarios(scenario).Run();

using var httpClient = new HttpClient();

var scenario = Scenario.Create("http_scenario", async context =>
{
    var request =
        Http.CreateRequest("GET", "https://nbomber.com")
            .WithHeader("Accept", "text/html")
            .WithBody(new StringContent("{ some JSON }"));

    var response = await Http.Send(httpClient, request);

    return response;
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 100,
                      interval: TimeSpan.FromSeconds(1),
                      during: TimeSpan.FromSeconds(30))
);

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();