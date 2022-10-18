using Interfaces;

namespace Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return (byte)context.Random.Next(0, 255);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Byte");
    }
}