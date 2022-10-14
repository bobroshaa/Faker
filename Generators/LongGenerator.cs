namespace Generators;

public class LongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return (long)(rnd.NextDouble() * long.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Int64");
    }
}