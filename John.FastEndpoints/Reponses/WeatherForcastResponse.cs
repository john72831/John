﻿namespace John.FastEndpoints.Reponses;

public class WeatherForcastResponse
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF { get; set; }

    public string? Summary { get; set; }
}
