using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Generators
{
    public class ICollectionSingleGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<Single>);

        public object GetValue()
        {
            return new Collection<Single>(){GetSingle(), GetSingle()};
        }
    }
}
