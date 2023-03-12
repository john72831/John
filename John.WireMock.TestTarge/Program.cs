public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.MapGet("/test", async () =>
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri(app.Configuration["Address"]) };
            var response = await httpClient.GetAsync("/innertest");
            var body = await response.Content.ReadAsStringAsync();

            return Results.Ok(body);
        });

        app.Run();
    }
}