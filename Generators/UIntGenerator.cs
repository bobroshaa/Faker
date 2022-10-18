using Configuration;
using Interfaces;

namespace Generators;

public class UIntGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (uint)(context.Random.NextDouble() * uint.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt32");
    }
}