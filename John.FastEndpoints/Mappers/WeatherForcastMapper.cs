using FastEndpoints;
using John.FastEndpoints.Models;
using John.FastEndpoints.Reponses;
using John.FastEndpoints.Requests;

namespace John.FastEndpoints.Mappers;

public class WeatherForcastMapper : Mapper<WeatherForecastRequest, WeatherForcastResponse, WeatherForecast>
{
    public override WeatherForcastResponse FromEntity(WeatherForecast e)
    {
        return new WeatherForcastResponse()
        {
            Date = e.Date,
            Summary = e.Summary,
            TemperatureC = e.TemperatureC,
            TemperatureF = e.TemperatureF,
        };
    }
}
