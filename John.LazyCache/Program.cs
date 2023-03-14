using LazyCache;
using Microsoft.Extensions.Caching.Memory;

LazyCacheApproach();

void MemoryCacheApproach()
{
    var cache = new MemoryCache(new MemoryCacheOptions());
    var counter = 0;

    Parallel.ForEach(Enumerable.Range(1, 50), _ =>
    {
        var cachedItem = cache.GetOrCreate("key", _ => Interlocked.Increment(ref counter));
        Console.Write($"{cachedItem} ");
    });
}

void LazyCacheApproach()
{
    var cache = new CachingService();
    var counter = 0;

    Parallel.ForEach(Enumerable.Range(1, 50), _ =>
    {
        var cachedItem = cache.GetOrAdd("key", _ => Interlocked.Increment(ref counter));
        Console.Write($"{cachedItem} ");
    });
}