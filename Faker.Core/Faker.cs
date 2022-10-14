using Generators;
namespace Faker.Core;
public class Faker
{
    private List<IValueGenerator> _generators;
    
    public Faker()
    {
        _generators = new List<IValueGenerator>() {new IntGenerator(), new DoubleGenerator()};
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
            // Для типов-значений вызов конструктора по умолчанию даст default(T).
            return Activator.CreateInstance(t);
        else
            // Для ссылочных типов значение по умолчанию всегда null.
            return null;
    }
}