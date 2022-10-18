using Configuration;
using Interfaces;

namespace Generators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (float)(context.Random.NextDouble() * (float.MaxValue - float.MinValue) + float.MinValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Single");
    }
}