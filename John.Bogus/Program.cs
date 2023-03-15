using Bogus;
using John.Bogus;
using System.Text.Json;

Randomizer.Seed = new Random(69);

var billingDetailsFaker = new Faker<BillingDetails>("zh_TW")
    .RuleFor( x=> x.CustomerName, x => x.Person.FullName)
    .RuleFor( x=> x.Email, x=> x.Person.Email)
    .RuleFor(x => x.Phone, x => x.Person.Phone)
    .RuleFor(x => x.AddressLine, x => x.Address.StreetAddress())
    .RuleFor(x => x.City, x => x.Address.City())
    .RuleFor(x => x.Country, x => x.Address.Country())
    .RuleFor(x => x.PostCode, x => x.Address.ZipCode());

var orderFaker = new Faker<Order>()
    .RuleFor(x => x.Id, Guid.NewGuid)
    .RuleFor(x => x.Currency, x => x.Finance.Currency().Code)
    .RuleFor(x => x.Price, x => x.Finance.Amount(5, 100))
    .RuleFor(x => x.BillingDetails, x => billingDetailsFaker);

//orderFaker.Generate();
//orderFaker.Generate(10);
var jsonSerializerOptions = new JsonSerializerOptions()
{
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    WriteIndented = true,
};

foreach (var order in orderFaker.GenerateForever())
{
    var text = JsonSerializer.Serialize(order, jsonSerializerOptions);

    Console.WriteLine(text);
    await Task.Delay(1000);
}
