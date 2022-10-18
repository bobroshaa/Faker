using Interfaces;

namespace Configuration;

public class GeneratorContext : IGeneratorContext
{
    public GeneratorContext(Random random, IFaker faker)
    {
        Random = random;
        Faker = faker;
    }
}