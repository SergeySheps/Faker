using System;

namespace Generators
{
    public class StringGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(String);

        public object GetValue()
        {
            return GetString();
        }
    }
}
