using System.Reflection;

namespace John.MethodTImer.Fody;

public static class MethodTimeLogger
{
    public static ILogger Logger;

    public static void Log(MethodBase methodbase, TimeSpan timeSpan, string message)
    {
        Logger.LogTrace("{Class}.{Method} {Duration}", methodbase.DeclaringType.Name, methodbase.Name, timeSpan);
    }
}
