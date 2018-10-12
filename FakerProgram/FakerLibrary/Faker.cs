using System;
using System.Collections.Generic;
using System.Linq;
using Generators;

namespace FakerLibrary
{
    public class Faker
    {
        private Dictionary<Type, IGenerator> generators;

        public Faker()
        {
            generators = new Dictionary<Type, IGenerator>();
        }

        public T Create<T>() where T : new()
        {
            Type type = typeof(T);
            T result = new T();

            foreach (var property in type.GetProperties())
            {
                if (property?.SetMethod != null && property.SetMethod.IsPublic)
                {
                    //ToDo save this result
                }
            }

            return result;
        }
    }

}
