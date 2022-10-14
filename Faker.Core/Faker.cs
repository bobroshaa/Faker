using System.Reflection.Emit;

namespace Faker.Core;
using Generators;
using System.Reflection;
using System.Linq;
public class Faker
{
    private List<IValueGenerator> _generators;
    
    public Faker()
    {
        _generators = Assembly.Load("Generators").GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
    }
    public T Create<T>()
    {
        return (T) Create(typeof(T));
    }
    public object Create(Type t)
    {
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(t))
            {
                return generator.Generate(t);
            }
        }
        return GetDefaultValue(t);
    }
    private static object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);
        else
            return null;
    }
}