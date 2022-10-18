namespace Interfaces;
public interface IValueGenerator
{
    object Generate(Type typeToGenerate, IGeneratorContext context);
    bool CanGenerate(Type type);
}



