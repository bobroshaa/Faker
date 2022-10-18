using Configuration;
using Interfaces;

namespace Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (sbyte)context.Random.Next(-128, 127);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.SByte");
    }
}