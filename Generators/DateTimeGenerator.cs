using Interfaces;

namespace Generators;

public class DateTimeGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return new DateTime(context.Random.Next(0, 2100), context.Random.Next(1, 12), context.Random.Next(0, 29),
            context.Random.Next(0, 24), context.Random.Next(0, 60), context.Random.Next(0, 60));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.DateTime");
    }
}