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
        }
    }
}
