using FastEndpoints;
using FastEndpoints.Swagger;
using John.FastEndpoints.Mappers;
using John.FastEndpoints.Models;
using John.FastEndpoints.Reponses;
using John.FastEndpoints.Requests;

namespace John.FastEndpoints.Endpoints
{
    public class WeatherForcastEndpoint : Endpoint<WeatherForecastRequest, WeatherForcastsResponse, WeatherForcastMapper>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForcastEndpoint> _logger;

        public WeatherForcastEndpoint(ILogger<WeatherForcastEndpoint> logger)
        {
            _logger = logger;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("weather/{days}");
            AllowAnonymous();
            Description(x => x.Produces<WeatherForcastsResponse>(200, "application/json"));
        }

        public override async Task HandleAsync(WeatherForecastRequest req, CancellationToken ct)
        {
            _logger.LogDebug("Retrieving weather for {Days} days", req.Days);

            var forecast = Enumerable.Range(1, req.Days).Select(index => new WeatherForecast
            (
                DateTime.Now.AddDays(index),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            )).ToArray();

            var response = new WeatherForcastsResponse
            {
                Forcasts = forecast.Select(Map.FromEntity)
            };

            await SendAsync(response, cancellation:ct);
        }
    }
}
