using Configuration;

namespace Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return context.Random.Next(0, 255);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Byte");
    }
}