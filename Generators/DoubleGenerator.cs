namespace Generators;

public class DoubleGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return (double)rnd.Next(0, 100000) / 1000;
    }

    public bool CanGenerate(Type type)
    {
        var t = Type.GetType("System.Double");
        return type == t;
    }
}