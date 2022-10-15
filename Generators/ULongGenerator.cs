using Configuration;

namespace Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return (ulong)(context.Random.NextDouble() * ulong.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt64");
    }
}