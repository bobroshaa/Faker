namespace Faker.Core;

class Program
{
    static void Main(string[] args)
    {
        var faker = new Faker();
        int i = faker.Create<int>(); // 542
        double d = faker.Create<double>(); // 12.458
        Console.WriteLine(i + "!!!" + d);
    }
}
