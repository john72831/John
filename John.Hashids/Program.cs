using HashidsNet;

var hashIds = new Hashids("John");
//var hashIds = new Hashids("John", 11);

//將1轉成hashId
var firstId = hashIds.Encode(1);

//將兩個數字轉成單一hashId
var secondId = hashIds.Encode(2, 3);

Console.WriteLine(firstId);
Console.WriteLine(secondId);

//還原
int[] firstRawId = hashIds.Decode(firstId);
var secondRawIds = hashIds.Decode(secondId);

Console.Read();