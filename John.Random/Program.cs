using System.Security.Cryptography;

var names = new[] { "Nick", "George", "Brooke", "Mike", "Chris", "Tom" };
var nameSpan = names.AsSpan();

//打亂陣列順序
Random.Shared.Shuffle(names);
Random.Shared.Shuffle(nameSpan);

var generatedNames = Random.Shared.GetItems(names, 50);

foreach (var name in generatedNames)
{
    Console.WriteLine(name);
}

var genString  = RandomNumberGenerator.GetString("abcdefg123456", 10);

Console.WriteLine(genString);

var hexString = RandomNumberGenerator.GetHexString(32);

Console.WriteLine(hexString);