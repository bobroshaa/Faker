using Configuration;
using Interfaces;

namespace Generators;

public class ShortGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (short)context.Random.Next(-32768, 32767);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Int16");
    }
}