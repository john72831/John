using Cocona;
using John.Cocona;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();

builder.Services.AddSingleton<IdGenerator>();

var app = builder.Build();

app.AddCommand("me", (string name, int age) =>
{
    Console.WriteLine($"My name us {name} and i am {age} years old");
});

app.AddCommand("id", (IdGenerator idGenerator) =>
{
    Console.WriteLine(idGenerator.Id);
});

app.AddCommands<MyCommand>();

app.Run();

//CoconaApp.Run((string name) =>
//{
//    Console.WriteLine($"Hello {name}");
//});