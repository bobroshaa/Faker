using Configuration;
using Interfaces;

namespace Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return Convert.ToChar(context.Random.Next(48, 122));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Char");
    }
}