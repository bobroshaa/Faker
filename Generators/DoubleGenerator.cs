using Configuration;

namespace Generators;

public class DoubleGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return (context.Random.NextDouble() - 0.5) * double.MaxValue;
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Double");
    }
}