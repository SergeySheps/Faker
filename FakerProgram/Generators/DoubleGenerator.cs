using System;

namespace Generators
{
    public class DoubleGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(double);

        public object GetValue()
        {
            return GetDouble();
        }
    }
}
