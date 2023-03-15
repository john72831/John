using John.MediatR.MinimalApi;
using John.MediatR.MinimalApi.Requests;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.MediateGet<ExampleRequest>("example/{name}");

app.Run();
