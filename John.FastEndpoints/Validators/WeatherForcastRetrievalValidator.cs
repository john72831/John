using FastEndpoints;
using FluentValidation;
using John.FastEndpoints.Requests;

namespace John.FastEndpoints.Validators;

public class WeatherForcastRetrievalValidator : Validator<WeatherForecastRequest>
{
    public WeatherForcastRetrievalValidator()
    {
        RuleFor(x => x.Days)
            .GreaterThanOrEqualTo(1).WithMessage("Weather forecast days must be at least 1")
            .LessThanOrEqualTo(14).WithMessage("Weather forcast can't be retrieved past 14 days");
    }
}
