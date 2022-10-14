namespace Generators;

public interface IValueGenerator
{
    object Generate(Type typeToGenerate);
    bool CanGenerate(Type type);
}



