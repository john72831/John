using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var config = TypeAdapterConfig.GlobalSettings;
config.NewConfig<Poco, Dto>();
services.AddSingleton(config);
services.AddScoped<IMapper, ServiceMapper>();

var provider = services.BuildServiceProvider();
var mapper = provider.GetRequiredService<IMapper>();

TypeAdapterConfig<Poco, Dto2>.NewConfig().Map(d => d.Name, s => s.Name + "_Mapster");

var dto = mapper.From(new Poco() { Name = "Test" }).AdaptToType<Dto>();
var dto2 = mapper.From(new Poco() { Name = "Test" }).AdaptToType<Dto2>();

Console.ReadLine();

class Poco
{
    public string Name { get; set; }
}

class Dto
{
    public string Name { get; set; }
}

class Dto2
{
    public string Name { get; set; }
}