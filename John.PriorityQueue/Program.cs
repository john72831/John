using System.Diagnostics;

var source = new CancellationTokenSource();
var queue = new PriorityQueue<string, (Status, long)>(StatusCompare.Instance);

queue.Enqueue("Mike", (Status.Normal, Stopwatch.GetTimestamp()));
queue.Enqueue("Nike", (Status.Gold, Stopwatch.GetTimestamp()));
queue.Enqueue("John", (Status.Gold, Stopwatch.GetTimestamp()));
queue.Enqueue("Poke", (Status.Normal, Stopwatch.GetTimestamp()));


while (!source.IsCancellationRequested)
{
    if (queue.Count > 0)
    {
        await Task.Delay(1000);
        Console.WriteLine(queue.Dequeue());
    }
}

enum Status
{
    Normal,
    Gold,
    Platinum
}

class StatusCompare : IComparer<(Status, long)>
{
    public static readonly StatusCompare Instance = new();

    int IComparer<(Status, long)>.Compare((Status, long) x, (Status, long) y)
    {
        if (x.Item1 == y.Item1)
            return x.CompareTo(y);

        return y.CompareTo(x);
    }
}