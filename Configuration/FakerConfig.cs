using System.Linq.Expressions;
using Interfaces;

namespace Configuration;

public class FakerConfig
{
    private Dictionary<Type, Dictionary<string, IValueGenerator>> _generators = new();
 
    //config.Add<Person, string, NameGenerator>(p => p.Name)
    public void Add<TClass, TType, TGenerator>(Expression<Func<TClass, TType>> exprTree)
    where TGenerator : IValueGenerator
    {
        BinaryExpression operation = (BinaryExpression)exprTree.Body; 
        ParameterExpression left = (ParameterExpression)operation.Left;
        var name = left.Name;
        var generator = (IValueGenerator)Activator.CreateInstance(typeof(TGenerator));
        _generators[typeof(TClass)].Add(name, generator);
        
        var member = exprTree.Body as MemberExpression ??
                     throw new ArgumentException("Expression must be a member expression");
        var memberName = member.Member.Name;
    }
    
}