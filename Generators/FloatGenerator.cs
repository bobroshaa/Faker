namespace Generators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        Random rnd = new Random();
        return (float)(rnd.NextDouble() * (float.MaxValue - float.MinValue) + float.MinValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.Single");
    }
}