using System.Diagnostics;

class Program
{
    private static Action<string> action => (x) => throw new Exception("Test");

    private static void Main(string[] args)
    {
        Test();

        void Test()
        {
            try
            {
                InnerFunction();

                void InnerFunction()
                {
                    action("error");
                }
            }
            catch (Exception ex)
            {
                //顯示原始stacktrace訊息
                Console.WriteLine(ex);
                //顯示強化後的stacktrace訊息
                Console.WriteLine(ex.Demystify());
            }
        }
    }
}

