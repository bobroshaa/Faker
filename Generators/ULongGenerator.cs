namespace Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return (ulong)(rnd.NextDouble() * ulong.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt64");
    }
}