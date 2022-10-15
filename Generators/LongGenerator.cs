using Configuration;

namespace Generators;

public class LongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return (long)(context.Random.NextDouble() * long.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Int64");
    }
}