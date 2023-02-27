using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Sigil;
using Sigil.NonGeneric;
using System.Reflection;

BenchmarkRunner.Run<ReflectionBenchmarks>();


[MemoryDiagnoser]
public class ReflectionBenchmarks
{
    [Benchmark]
    public string TraditionalReflection() => ReflectionUsage.TraditionalReflection();

    [Benchmark]
    public string OptimizedTraditionalReflection() => ReflectionUsage.OptimizedTraditionalReflection();

    [Benchmark]
    public string CompiledDelegate() => ReflectionUsage.CompiledDelegate();

    [Benchmark]
    public string EmittedIlVersion() => ReflectionUsage.EmittedIlVersion();
}

class ReflectionUsage
{
    private static readonly VeryPublicClass VeryPublicClass = new VeryPublicClass();

    public static string TraditionalReflection()
    {
        var propertyInfo = VeryPublicClass.GetType().GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = propertyInfo!.GetValue(VeryPublicClass);

        return value!.ToString();
    }

    private static readonly PropertyInfo CachedProperty = typeof(VeryPublicClass).GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic)!;

    public static string OptimizedTraditionalReflection()
    {
        var value = CachedProperty!.GetValue(VeryPublicClass);

        return value!.ToString();
    }

    private static readonly Func<VeryPublicClass, string> GetPropertyDelegate = (Func<VeryPublicClass, string>)Delegate.CreateDelegate(typeof(Func<VeryPublicClass, string>), CachedProperty.GetGetMethod(true)!);

    public static string CompiledDelegate()
    {
        return GetPropertyDelegate(VeryPublicClass);
    }

    private static readonly Type VeryInteralClassType = Type.GetType("VeryInternalClass, John.Reflection")!;

    private static readonly PropertyInfo CachedInteralProperty = VeryInteralClassType.GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly Emit<Func<object, string>> GetPropertyEmitter = Emit<Func<object, string>>
        .NewDynamicMethod("GetInternalPropertyValue")
        .LoadArgument(0)
        .CastClass(VeryInteralClassType)
        .Call(CachedInteralProperty.GetGetMethod(true)!)
        .Return();

    private static readonly Func<object, string> GetPropertyEmittedDelegate = GetPropertyEmitter.CreateDelegate();

    private static readonly object VeryInternalClass  = Activator.CreateInstance(VeryInteralClassType);

    public static string EmittedIlVersion()
    {
        return GetPropertyEmittedDelegate(VeryInternalClass);
    }
}