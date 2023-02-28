using Cupboard;
using John.Cupboard;

CupboardHost.CreateBuilder()
    .AddCatalog<WindowsComputer>()
    .Build()
    .Run(args);