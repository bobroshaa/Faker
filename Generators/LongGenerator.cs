using Configuration;
using Interfaces;

namespace Generators;

public class LongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (long)(context.Random.NextDouble() * long.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Int64");
    }
}