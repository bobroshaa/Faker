using System.Linq.Expressions;
using Interfaces;

namespace Configuration;

public class FakerConfig
{
    private Dictionary<Type, Dictionary<string, IValueGenerator>> _generators = new();
    
    public void Add<TClass, TType, TGenerator>(Expression<Func<TClass, TType>> exprTree)
    where TGenerator : IValueGenerator
    {
        var name = ((MemberExpression)exprTree.Body).Member.Name;  
        var generator = (IValueGenerator)Activator.CreateInstance(typeof(TGenerator));
        if (_generators.ContainsKey(typeof(TClass)))
            _generators[typeof(TClass)].Add(name, generator);
        else
        {
            _generators.Add(typeof(TClass), new Dictionary<string, IValueGenerator>() { [name] = generator });
        }
    }

    public bool CanGenerate(Type type, string name)
    {
        return _generators.ContainsKey(type) && _generators[type].ContainsKey(name);
    }

    public IValueGenerator GetGenerator(Type type, string name)
    {
        var info = new Dictionary<string, IValueGenerator>();
        _generators.TryGetValue(type, out info);
        if (info != null)
        {
            IValueGenerator generator;
            info.TryGetValue(name, out generator);
            return generator;
        }

        return null;
    }
    
}