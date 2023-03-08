internal class Program
{
    //TestStruct error = new TestStruct();

    public static void Main(string[] args)
    {
        var testClass = new TestClass() { Value = 10 };
        ChangeTestClassValue(testClass);

        Console.WriteLine(testClass.Value);

        var testStruct = new TestStruct() { Value = 10};
        ChangeTestStructValue(testStruct);

        Console.WriteLine(testStruct.Value);

        var numbers = new[] { 69, 420 };
        ref var value = ref GetNumberInPosition(numbers, 1);
        //numbers[1] changed to 1 too!
        value = 10;
        Console.WriteLine(value);

        void ChangeTestClassValue(TestClass value)
        {
            value = new TestClass() { Value = 20 };
        }

        void ChangeTestStructValue(TestStruct value){
            value.Value = 20;
        }

        ref int GetNumberInPosition(int[] numbers, int index)
        {
            return ref numbers[index];
        }
    }
}

 class TestClass
{
    public int Value { get; set; }
}


ref struct TestStruct
{
    public int Value { get; set; }
}

