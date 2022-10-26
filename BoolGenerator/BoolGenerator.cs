using Interfaces;

namespace BoolGenerator;

public class BoolGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return context.Random.Next(0, 2) != 0;
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Boolean");
    }
}