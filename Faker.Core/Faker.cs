using Generators;
using System.Reflection;
using Interfaces;
using Configuration;

namespace Faker.Core;

public class Faker : IFaker
{
    private List<IValueGenerator> _generators;
    private GeneratorContext _generatorContext;
    private static List<Type> _types = new List<Type>();

    // Get all generators
    public Faker()
    {
        _generators = Assembly.Load("Generators").GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
        _generatorContext = new GeneratorContext(new Random(), this);
    }
    
    public T Create<T>()
    {
        return (T) Create(typeof(T));
    }

    public object Create(Type t)
    {
        // Check if this variable of primitive type
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(t))
            {
                return generator.Generate(t, _generatorContext);
            }
        }

        // Check for looping
        if (_types.Contains(t)) 
            return GetDefaultValue(t);
        _types.Add(t);
        
        // Get constructors of class
        object[] args = GetBestConstructor(t).GetParameters().Select(x => Create(x.ParameterType)).ToArray();
        object instance = Activator.CreateInstance(t, args);
        
        // Filling null fields and properties
        GetFields(t, instance);
        GetProperties(t, instance);
        _types.Remove(t);
        
        // If previous code can't fill this variable default value is assigned 
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