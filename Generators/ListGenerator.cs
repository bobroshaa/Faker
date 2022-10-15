using System.Collections;
using Configuration;

namespace Generators;

public class ListGenerator : IValueGenerator
{
    public object Generate(Type typeToGenerate, GeneratorContext context)
    {
        var size = context.Random.Next(1, 11);
        var type = typeToGenerate.GetGenericArguments()[0];
        Type genericListType = typeof(List<>).MakeGenericType(type);
        var res = (IList)Activator.CreateInstance(genericListType);
        for (int i = 0; i < size; ++i)
        {
            res.Add(context.Faker.Create(typeToGenerate.GetGenericArguments()[0]));
        }

        return res;
    }

    public bool CanGenerate(Type type)
    {
        return type.ToString().Contains("System.Collections.Generic.List");
    }
}