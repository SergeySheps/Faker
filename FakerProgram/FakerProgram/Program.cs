using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLibrary;

namespace FakerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Foo foo = faker.Create<Foo>();
            var randomizer = new CustomRandomizer();

            Console.WriteLine(randomizer.GetDouble());
            Console.WriteLine(randomizer.GetString());
            Console.WriteLine(randomizer.GetDateTime());
            Console.ReadKey();
        }
    }
}
