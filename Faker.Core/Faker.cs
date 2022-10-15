using System.Reflection.Emit;

namespace Faker.Core;
using Generators;
using System.Reflection;
using System.Linq;
public class Faker
{
    private List<IValueGenerator> _generators;
    
    // Get all generators
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
        object instance = null;
        // Check if this variable of primitive type
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(t))
            {
                instance = generator.Generate(t);
            }
        }
        // Try to get constructors of class
        if (instance == null)
        {
            object[] args = GetBestConstructor(t).GetParameters().Select(x => Create(x.ParameterType)).ToArray();
            instance = Activator.CreateInstance(t, args);
            GetFields(t, instance);
            GetProperties(t, instance);
        }
        if (instance == null)
            instance = GetDefaultValue(t);
        return instance;
    }

    public ConstructorInfo GetBestConstructor(Type type)
    {
        ConstructorInfo[] constructors = type.GetConstructors();
        var res = constructors[0];
        foreach (var constructor in constructors)
        {
            if (constructor.GetParameters().Length > res.GetParameters().Length)
                res = constructor;
        }
        return res;
    }

    public void GetFields(Type type, object instance)
    {
        FieldInfo[] fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.GetValue(instance) == null)
            {
                field.SetValue(instance, Create(field.FieldType));
            }
        }
    }
    
    public void GetProperties(Type type, object instance)
    {
        PropertyInfo[] properties = type.GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(instance) == null || property.GetValue(instance).Equals(0))
            {
                property.SetValue(instance, Create(property.PropertyType));
            }
        }
    }
    private static object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);
        else
            return null;
    }
}