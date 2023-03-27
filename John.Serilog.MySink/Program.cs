using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using static Program;

public class Program
{
    private static void Main(string[] args)
    {
        var log = new LoggerConfiguration()
              .MinimumLevel.Information()
              .WriteTo.File("", LogEventLevel.Warning)
              .CreateLogger();

        var position = new { Latitude = 25, Longitude = 134 };
        var elapsedMs = 34;

        log.Information("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);
    }
}

public class MySink : ILogEventSink
{
    private readonly IFormatProvider _formatProvider;

    public MySink(IFormatProvider formatProvider)
    {
        _formatProvider = formatProvider;
    }

    public void Emit(LogEvent logEvent)
    {
        var message = logEvent.RenderMessage(_formatProvider);
        Console.WriteLine(DateTimeOffset.Now.ToString() + " " + message);
    }
}

public static class MySinkExtensions
{
    public static LoggerConfiguration MySink(
              this LoggerSinkConfiguration loggerConfiguration,
              IFormatProvider formatProvider = null)
    {
        return loggerConfiguration.Sink(new MySink(formatProvider));
    }
}