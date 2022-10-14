namespace Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return rnd.Next(-128, 127);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.SByte");
    }
}