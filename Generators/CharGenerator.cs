using Configuration;

namespace Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        return Convert.ToChar(context.Random.Next(48, 122));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Char");
    }
}