using System.Reflection;
using Interfaces;
using Configuration;

namespace Faker.Core;

public class Faker : IFaker
{
    private List<IValueGenerator> _generators;
    private GeneratorContext _generatorContext;
    private static List<Type> _types = new List<Type>();
    private FakerConfig _config;
    
    public Faker()
    {
        // Get all generators
        _generators = Assembly.Load("Generators").GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
        
        // Get generators from plugins
        string[] allFiles = Directory.GetFiles("Plugins");
        foreach (string filename in allFiles)
        {
            var list = Assembly.LoadFrom(filename).GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
                .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
            foreach (var generator in list)
            {
                _generators.Add(generator);
            }
        }
        _generatorContext = new GeneratorContext(new Random(), this);
    }

    public Faker(FakerConfig config) : this()
    {
        _config = config;
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
        object[] args = GetBestConstructor(t).GetParameters()
            .Select(x => GenerateValue(x.ParameterType, t, x.Name)).ToArray();
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
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var field in fields)
        {
            field.SetValue(instance, GenerateValue(field.FieldType, type, field.Name));
        }
    }
    
    public void GetProperties(Type type, object instance)
    {
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var property in properties)
        {
            property.SetValue(instance, GenerateValue(property.PropertyType, type, property.Name));
        }
    }
    
    public static object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);
        return null;
    }

    public object GenerateValue(Type memberType, Type objType, string memberName)
    {
        if (_config != null && _config.CanGenerate(objType, memberName))
            return _config.GetGenerator(objType, memberName).Generate(objType, _generatorContext);
        return Create(memberType);
    }
}