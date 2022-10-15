using Configuration;

namespace Generators;

public class IntGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return context.Random.Next(-2147483648, 2147483647);
    }

    public bool CanGenerate(Type type)
    {
        var t = Type.GetType("System.Int32");
        return type == t;
    }
}