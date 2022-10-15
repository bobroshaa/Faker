using Configuration;

namespace Generators;

public class UIntGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return (uint)(context.Random.NextDouble() * uint.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt32");
    }
}