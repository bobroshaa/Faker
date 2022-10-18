using Configuration;
using Interfaces;

namespace Generators;

public class StringGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, IGeneratorContext context)
    {
        var generator = new CharGenerator();
        var res = "";
        int length  = context.Random.Next(255);
        for (int i = 0; i < length; ++i)
        {
            res += generator.Generate(Type.GetType("System.Boolean"), context);
        }
        return res;
    }

    public bool CanGenerate(Type type)
    {
        return type == Type.GetType("System.String");
    }
}