using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

var wireMockServer = WireMockServer.Start();

Console.WriteLine($"Server is running at: {wireMockServer.Urls[0]}");

wireMockServer
    .Given(Request.Create().WithPath("/test").UsingGet())
    .RespondWith(Response.Create().WithBody("Hello from WireMock!!!"));

Console.ReadKey();
wireMockServer.Stop();
wireMockServer.Dispose();