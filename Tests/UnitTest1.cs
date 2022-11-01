using Configuration;
using Interfaces;

namespace Tests;

public class Tests
{
    [Test]
    public void GeneratorTests()
    {
        Faker.Core.Faker faker = new Faker.Core.Faker();
        Assert.That(faker.Create<byte>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(byte))));
        Assert.That(faker.Create<bool>(), Is.AnyOf(true, false));
        
        Assert.That(faker.Create<short>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(short))));
        Assert.That(faker.Create<ushort>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(ushort))));
        
        Assert.That(faker.Create<int>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(int))));
        Assert.That(faker.Create<uint>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(uint))));
        
        Assert.That(faker.Create<long>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(long))));
        Assert.That(faker.Create<ulong>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(ulong))));
        
        Assert.That(faker.Create<float>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(float))));
        Assert.That(faker.Create<double>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(double))));
        
        Assert.That(faker.Create<char>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(char))));
        Assert.That(faker.Create<string>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(string))));
        
        Assert.That(faker.Create<List<int>>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(List<int>))));
        
        Assert.That(faker.Create<DateTime>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(DateTime))));
    }
    
    class A
    {
        public B b{ get; set; }
    }

    class B
    {
        public C c{ get; set; }
    }

    class C
    {   
        public A a{ get; set; } 
    }

    [Test]
    public void CycleTests()
    {
        Faker.Core.Faker faker = new Faker.Core.Faker();
        Assert.That(faker.Create<A>().b.c.a, Is.Null);
    }

    class User
    {
        public User(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Age { get; set; }
    }
    
    [Test]
    public void CreatingClass()
    {
        Faker.Core.Faker faker = new Faker.Core.Faker();
        Assert.That(faker.Create<User>().Age, Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(int))));
        Assert.That(faker.Create<User>().Name, Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(string))));
    }

    class Foo
    {
        public string City { get; set; }
        public int Population { get; set; }
    }
    class CityGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            return "Mozyr";
        }

        public bool CanGenerate(Type type)
        {
            return type == Type.GetType("System.String");
        }
    }
    class PopulationGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, IGeneratorContext context)
        {
            return context.Random.Next(90000, 100000);
        }

        public bool CanGenerate(Type type)
        {
            return type == Type.GetType("System.Int32");
        }
    }
    
    [Test]
    public void FakerConfigTest()
    {
        var config = new FakerConfig();
        config.Add<Foo, string, CityGenerator>(foo => foo.City);
        config.Add<Foo, int, PopulationGenerator>(foo => foo.Population);
        var faker = new Faker.Core.Faker(config);
        Foo foo = faker.Create<Foo>();
        Assert.That(foo.City, Is.EqualTo("Mozyr"));
        Assert.That(foo.Population, Is.GreaterThanOrEqualTo(90000));
        Assert.That(foo.Population, Is.LessThan(100000));
    }
}