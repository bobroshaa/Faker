using Configuration;

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
        User user = faker.Create<User>();
        Console.WriteLine("user" + " " + user.Age + " " + user.Name);
        Console.WriteLine(faker.Create<List<bool>>()[0]);
        
    }
}

class User
{
    /*public User(string name, int age)
    {
        Name = name;
        Age = age;
    }*/
    public string Name { get; set; }
    public int Age { get; set; }
}
