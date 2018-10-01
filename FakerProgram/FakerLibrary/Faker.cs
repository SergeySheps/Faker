using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    public class Faker
    {
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
