namespace Generators;

public class IntGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return rnd.Next(-2147483648, 2147483647);
    }

    public bool CanGenerate(Type type)
    {
        var t = Type.GetType("System.Int32");
        return type == t;
    }
}