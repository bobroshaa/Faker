namespace Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return rnd.Next(0, 255);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Byte");
    }
}