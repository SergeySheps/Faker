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
        private List<object> nestedObjects;

        public Faker()
        {
            generators = new Dictionary<Type, IGenerator>();
            nestedObjects = new List<object>();
            generators.Add(typeof(String), (IGenerator)Activator.CreateInstance(typeof(StringGenerator)));
            generators.Add(typeof(Int32), (IGenerator)Activator.CreateInstance(typeof(Int32Generator)));
            generators.Add(typeof(Int64), (IGenerator)Activator.CreateInstance(typeof(Int64Generator)));
            generators.Add(typeof(float), (IGenerator)Activator.CreateInstance(typeof(FloatGenerator)));
            generators.Add(typeof(double), (IGenerator)Activator.CreateInstance(typeof(DoubleGenerator)));
            generators.Add(typeof(DateTime), (IGenerator)Activator.CreateInstance(typeof(DateTimeGenerator)));
            GetGenerators();
        }

        private void GetGenerators()
        {
            var asm = Assembly.LoadFrom("Plugins.dll");
            foreach (var type in asm.GetTypes())
            {
                if (type.GetInterface(typeof(IGenerator).FullName) != null)
                {
                    var gen = (IGenerator)Activator.CreateInstance(type);
                    generators.Add(gen.Type, gen);
                }
            }
        }

        public T Create<T>(object nested = null) where T : new()
        {
            if (nested != null)
            {
                nestedObjects.Add(nested);
            }

            var constructors = typeof(T).GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var constructor = constructors.First();

            var parametersInfo = constructor.GetParameters();
            var parameters = new object[parametersInfo.Length];

            for (int i = 0; i < parametersInfo.Length; i++)
            {
                if (generators.TryGetValue(parametersInfo[i].ParameterType, out var generator))
                {
                    parameters[i] = generator.GetValue();
                }
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
            {
                property.SetMethod.Invoke(result, new[] { generator.GetValue() });
            }
            else if (propertyType.Name == objectType)
            {
                property.SetMethod.Invoke(result, new object[] { result });
            }
            else if (nestedObjects.Find(x => x.GetType() == propertyType) != null)
            {
                property.SetMethod.Invoke(result, new[] { nestedObjects.Find(x => x.GetType() == propertyType) });
            }
            else
            {
                property.SetMethod.Invoke(result, new[] { GetDTO(ref result, propertyType) });
            }
        }

        private object GetDTO<T>(ref T result, Type property)
        {
            try
            {
                var method = typeof(Faker).GetMethod("Create", BindingFlags.Instance | BindingFlags.Public);
                var genericMethod = method?.MakeGenericMethod(property);
                var dto = genericMethod?.Invoke(this, new object[] { result });
                return dto;
            }
            catch (Exception)
            {
                // if unknown dto
            }

            return null;
        }

    }

}
