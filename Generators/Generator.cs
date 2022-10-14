namespace Generators;

public interface IValueGenerator
{
    object Generate(Type typeToGenerate);
    // Позволяет реализовывать сколь угодно сложную логику определения,
    // подходит ли генератор. Таким образом можно работать с генераторами
    // коллекций аналогично генераторам примитивных типов.
    bool CanGenerate(Type type);
}



