using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using StackExchange.Redis;
using static System.Net.Mime.MediaTypeNames;

const string weatherForecastStorage = "weatherForecastStorage";

var mssqlConfiguration = new MsSqlTestcontainerConfiguration();
mssqlConfiguration.Password = Guid.NewGuid().ToString("D");
mssqlConfiguration.Database = Guid.NewGuid().ToString("D");

var connectionString = $"server={weatherForecastStorage};user id=sa;password={mssqlConfiguration.Password};database={mssqlConfiguration.Database}";

var _weatherForecastNetwork = new NetworkBuilder()
  .WithName(Guid.NewGuid().ToString("D"))
  .Build();

//var _mssqlContainer = new ContainerBuilder<MsSqlTestcontainer>()
//  .WithDatabase(mssqlConfiguration)
//  .WithNetwork(_weatherForecastNetwork)
//  .WithNetworkAliases(weatherForecastStorage)
//  .Build();

var _redisContainer = new ContainerBuilder<RedisTestcontainer>()
  .WithDatabase(new RedisTestcontainerConfiguration())
  //.WithNetwork(_weatherForecastNetwork)
  .WithNetworkAliases(weatherForecastStorage)
  .Build();

await _weatherForecastNetwork.CreateAsync().ConfigureAwait(false);

//await _mssqlContainer.StartAsync();

await _redisContainer.StartAsync().ConfigureAwait(false);

var multiplexer = await ConnectionMultiplexer.ConnectAsync(_redisContainer.ConnectionString);
var database = multiplexer.GetDatabase();
await database.StringSetAsync("RandomNumber", "420");
var value = await database.StringGetAsync("RandomNumber");

Console.ReadLine();