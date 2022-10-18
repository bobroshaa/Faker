namespace Interfaces;

public class IGeneratorContext
{
    public Random Random { get; set; }
    public IFaker Faker { get; set; }
}