namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void GeneratorTests()
    {
        Faker.Core.Faker faker = new Faker.Core.Faker();
        Assert.That(faker.Create<byte>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(byte))));
        Assert.That(faker.Create<bool>(), Is.Not.EqualTo(Faker.Core.Faker.GetDefaultValue(typeof(bool))));
        
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
    
}