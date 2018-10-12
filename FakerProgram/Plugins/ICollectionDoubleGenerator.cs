using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Generators
{
    public class ICollectionDoubleGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<Double>);

        public object GetValue()
        {
            return new Collection<Double>() { GetDouble(), GetDouble(), GetDouble() };
        }
    }
}
