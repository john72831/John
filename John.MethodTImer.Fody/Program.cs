
using John.MethodTImer.Fody;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();
MethodTimeLogger.Logger = app.Logger;

app.MapGet("/", () => {
    new MyClass().Test();
});

app.Run();