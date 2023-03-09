using Humanizer;
using System.ComponentModel;
using System.Globalization;

var traditionalChinese = new CultureInfo("zh-Hant");

var strings = new Func<string>[]
{
    //General
    () => "This is the story of my life".Truncate(14, "..."),
    () => ExampleEnum.FirstValue.Humanize(),

    //DateTime
    () => DateTime.UtcNow.AddHours(2).Humanize(),

    //TimeSpans
    () => TimeSpan.FromMilliseconds(252000).Humanize(1),

    //Case
    () => "John Lin".Pascalize(),

    //Culture
    () => 1.ToOrdinalWords(traditionalChinese),
    () => 69.Millions().ToString()
};

foreach (var textFunc in strings)
{
    Console.WriteLine(textFunc());
}

enum ExampleEnum
{
    [Description("First Value")]
    FirstValue,
    SecondValue
}