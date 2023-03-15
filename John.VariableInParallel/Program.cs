using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Benchy>();

[MemoryDiagnoser(false)]
public class Benchy
{
    [Params(10000, 10000000)]
    public int Range { get; set; }

    [Params(2,4,8)]
    public int MaxDegreeOfParallelism { get; set; }

    [Benchmark]
    public void For()
    {
        var numbers = Enumerable.Range(1, Range);
        long sumOfNumbers = 0;
        Action<long> taskFinishedMethod = (taskResult) =>
        {
            Interlocked.Add(ref sumOfNumbers, taskResult);
        };

        Parallel.For(
            0,
            numbers.Count() + 1,
            new ParallelOptions() { MaxDegreeOfParallelism = MaxDegreeOfParallelism },
            () => 0, // initialize the thread local variable
            (j, parallelLoopState, subtotal) =>
            {
                subtotal += j;
                return subtotal;
            }, // method invoked by the loop on each iteration
            taskFinishedMethod
        );
    }

    [Benchmark]
    public void Foreach()
    {
        var numbers = Enumerable.Range(1, Range);
        long sumOfNumbers = 0;
        Action<long> taskFinishedMethod = (taskResult) =>
        {
            Interlocked.Add(ref sumOfNumbers, taskResult);
        };

        Parallel.ForEach(
            numbers,
            new ParallelOptions() { MaxDegreeOfParallelism = MaxDegreeOfParallelism },
            () => 0, (j, parallelLoopState, subtotal) =>
            {
                subtotal += j;
                return subtotal;
            }, taskFinishedMethod);
    }
}