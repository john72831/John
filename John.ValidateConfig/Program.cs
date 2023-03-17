using FluentValidation;
using John.ValidateConfig;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

builder.Services.AddOptions<ExampleOptions>()
    .Bind(config.GetSection(ExampleOptions.SectionName))
    //.Validate( x=>
    //{
    //    if (x.Retries is <= 0 or > 10)
    //        return false;

    //    return true;
    //})
    //.ValidateDataAnnotations()
    .ValidateFluently()
    .ValidateOnStart();

var app = builder.Build();

app.Run();
