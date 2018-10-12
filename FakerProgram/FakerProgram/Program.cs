using System;
using FakerLibrary;
using Newtonsoft.Json;

namespace FakerProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            Faker faker = new Faker();
            var foo = faker.Create<Foo>();
            OutputProperties(foo);
            //var result = JsonConvert.SerializeObject(foo, Formatting.Indented, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //Console.WriteLine(result);
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
                    Console.WriteLine(property.PropertyType.Name+ " " + property.Name + ": " + propertyValue);

                }
            }
            Console.WriteLine();
        }
    }
}
