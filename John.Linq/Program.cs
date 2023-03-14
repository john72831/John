var names = new[] { "A", "B", "C", "D", "E", "F", "G" };
var age = new[] { 1, 2, 3, 4, 5, 6, 7 };
var chunked = names.Chunk(3);

if (names.TryGetNonEnumeratedCount(out var count)){}

var ziped = names.Zip(age);
var min = age.MinBy(x => x);
var max = age.MaxBy(x => x);
var thirdItemFromTheEnd = age.ElementAt(^3);
var slice = names.Take(2..4);
var lastThree = names.Take(^3..);

Console.ReadKey();