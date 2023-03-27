using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using John.Span;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;

class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchy>();
    }
}

[MemoryDiagnoser(false)]
public class Benchy
{
    private static readonly string _dateAsText = "08 07 2021";
    private static readonly Guid TestIdAsString = Guid.Parse("18755b4a-3ce6-4abb-85d3-44b80facb9dd");
    private static readonly string TestIdAsGuid = "Slt1GOY8u0qF00S4D6y53Q";

    //[Benchmark]
    //public (int day, int month, int year) DateWithStringAndSubString()
    //{
    //    var dayAsText = _dateAsText.Substring(0, 2);
    //    var monthAsText = _dateAsText.Substring(3, 2);
    //    var yearAsText = _dateAsText.Substring(6);
    //    var day = int.Parse(dayAsText);
    //    var month = int.Parse(monthAsText);
    //    var year = int.Parse(yearAsText);

    //    return (day, month, year);
    //}

    //[Benchmark]
    //public (int day, int month, int year) DateWithStringAndSpan()
    //{
    //    ReadOnlySpan<char> dateAsSpan = _dateAsText;
    //    var dayAsText = dateAsSpan.Slice(0, 2);
    //    var monthAsText = dateAsSpan.Slice(3, 2);
    //    var yearAsText = dateAsSpan.Slice(6);
    //    var day = int.Parse(dayAsText);
    //    var month = int.Parse(monthAsText);
    //    var year = int.Parse(yearAsText);

    //    return (day, month, year);
    //}

    [Benchmark]
    public string ToStringFromGuid()
    {
        return Guider.ToStringFromGuidOp(TestIdAsString);
    }

    [Benchmark]
    public Guid ToGuidFromString()
    {
        return Guider.ToGuidFromStringOp(TestIdAsGuid);
    }
}