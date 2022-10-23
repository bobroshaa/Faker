using Interfaces;

namespace Generators;

public class DateTimeGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return new DateTime(context.Random.Next(0, 2100), context.Random.Next(0, 13), context.Random.Next(0, 32), context.Random.Next(0, 25), context.Random.Next(0, 61), context.Random.Next(0, 61));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.DateTime");
    }
}