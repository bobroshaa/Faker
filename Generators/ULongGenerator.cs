using Configuration;
using Interfaces;

namespace Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (ulong)(context.Random.NextDouble() * ulong.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt64");
    }
}