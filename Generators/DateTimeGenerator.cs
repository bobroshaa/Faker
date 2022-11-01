using Interfaces;

namespace Generators;

public class DateTimeGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        return new DateTime(context.Random.Next(1, 9999), context.Random.Next(1, 13), context.Random.Next(1, 29),
            context.Random.Next(0, 24), context.Random.Next(0, 60), context.Random.Next(0, 60));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.DateTime");
    }
}