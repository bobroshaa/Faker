namespace Generators;

public class StringGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate)
    {
        var rnd = new Random();
        var generator = new CharGenerator();
        var res = "";
        int length  = rnd.Next(255);
        for (int i = 0; i < length; ++i)
        {
            res += generator.Generate(Type.GetType("System.Boolean"));
        }
        return res;
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.String");
    }
}