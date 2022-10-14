namespace Generators;

public class ShortGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return rnd.Next(-32768, 32767);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Int16");
    }
}