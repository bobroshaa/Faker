using Configuration;

namespace Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return context.Random.Next(-128, 127);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.SByte");
    }
}