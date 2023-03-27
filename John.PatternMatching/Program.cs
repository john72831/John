decimal balance = 0m;

var records = new string[][] {
    new string[]{ "04-01-2020", "DEPOSIT", "Initial deposit", "2250.00" },
    new string[]{ "04-22-2020", "WITHDRAWAL", "Debit","Groceries", "255.73"},
    new string[]{ "05-02-2020", "INTEREST", "0.65" }
};

foreach (string[] transaction in records)
{
    balance += transaction switch
    {
        [_, "DEPOSIT", _, var amount] => decimal.Parse(amount),
        [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
        [_, "INTEREST", var amount] => decimal.Parse(amount),
        [_, "FEE", var fee] => -decimal.Parse(fee),
        _ => throw new InvalidOperationException($"Record {string.Join(", ", transaction)} is not in the expected format!"),
    };
    Console.WriteLine($"Record: {string.Join(", ", transaction)}, New balance: {balance:C}");
}

CalculateDiscount(new Order(6, 60.00m));

decimal CalculateDiscount(Order order) =>
    order switch
    {
        ( > 10, > 1000.00m) => 0.10m,
        ( > 5, > 50.00m) => 0.05m,
        { Cost: > 250.00m } => 0.02m,
        null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        var someObject => 0m,
    };

string WaterState2(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        < 32 => "solid",
        32 => "solid/liquid transition",
        < 212 => "liquid",
        212 => "liquid / gas transition",
        _ => "gas",
    };

public record Order(int Items, decimal Cost);