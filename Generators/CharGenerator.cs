namespace Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return Convert.ToChar(rnd.Next(48, 122));
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Char");
    }
}