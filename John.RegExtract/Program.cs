using RegExtract;

var phrase = "Oh something happened at: Fri, 4 February 2022";
var regexPattern  = "Oh something happened at: (.*)";

var dateonly = phrase.Extract<DateOnly>(regexPattern);
Console.WriteLine(dateonly);

Console.ReadLine();