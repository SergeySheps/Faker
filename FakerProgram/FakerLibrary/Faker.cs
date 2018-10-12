using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Generators;

namespace FakerLibrary
{
    public class Faker
    {
        private Dictionary<Type, IGenerator> generators;

        public Faker()
        {
            generators = new Dictionary<Type, IGenerator>();
            generators.Add(typeof(String), (IGenerator)Activator.CreateInstance(typeof(StringGenerator)));
            generators.Add(typeof(Int32), (IGenerator)Activator.CreateInstance(typeof(Int32Generator)));
        }

        public T Create<T>() where T : new()
        {
            var constructors = typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var constructor = constructors.First();

            var parametersInfo = constructor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                if (generators.TryGetValue(parametersInfo[i].ParameterType, out var generator))
                    parameters[i] = generator.GetValue();
            }

            var result = constructor.Invoke(parameters);

            foreach (var property in typeof(T).GetProperties())
            {
                if (property?.SetMethod != null && property.SetMethod.IsPublic)
                {
                    SetValue(ref result, property);
                }
            }

            return (T)result;
        }

        private void SetValue<T>(ref T result, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            string objectType = result.GetType().Name;

            if (generators.TryGetValue(propertyType, out var generator))
                property.SetMethod.Invoke(result, new[] { generator.GetValue() });
            else if (propertyType.Name == objectType)
            {
                property.SetMethod.Invoke(result, new object[] { result });
            }
        }

    }

}
