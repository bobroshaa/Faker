using Configuration;
using Interfaces;

namespace Generators;

public class UShortGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (ushort)context.Random.Next(0, 65535);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt16");
    }
}