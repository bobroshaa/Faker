namespace Generators;

public class UShortGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return (ushort)rnd.Next(0, 65535);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.UInt16");
    }
}