namespace Generators;

public class BoolGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return rnd.Next(0, 2) != 0;
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Boolean");
    }
}