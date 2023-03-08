using MethodTimer;

namespace John.MethodTImer.Fody;

public class MyClass
{
    [Time]
    public void Test()
    {
        Console.WriteLine("");
    }
}
