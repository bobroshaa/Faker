namespace Faker.Core;

class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker();
        Console.WriteLine("int" + faker.Create<int>());
        Console.WriteLine("ushort" + faker.Create<ushort>());
        Console.WriteLine("bool" + faker.Create<bool>());
        Console.WriteLine("char" + faker.Create<char>());
        Console.WriteLine("string" + faker.Create<string>());
        Console.WriteLine("double" + faker.Create<double>());
        Console.WriteLine("long" + faker.Create<long>());
    }
}
