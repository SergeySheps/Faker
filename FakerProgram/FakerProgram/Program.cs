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
            var foo = faker.Create<Bar>();
            OutputProperties(foo);

            Console.ReadKey();
        }

        private static void OutputProperties(object value)
        {
            Console.WriteLine("Class: " + value.GetType().Name);
            foreach (var property in value.GetType().GetProperties())
            {
                if (property?.GetMethod != null)
                {
                    var propertyValue = property.GetValue(value);
                    Console.WriteLine(property.Name + ": " + propertyValue);

                }
            }
            Console.WriteLine();
        }
    }
}
