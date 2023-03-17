using System.ComponentModel.DataAnnotations;

namespace John.ValidateConfig;

public class ExampleOptions
{
    public const string SectionName = "Example";

    [EnumDataType(typeof(LogLevel))]
    public required string LogLevel { get; set; }

    [Range(1, 10)]
    public required int Retries { get; set; }
}
