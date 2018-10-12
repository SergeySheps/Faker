using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Generators
{
    public class ICollectionStringGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<string>);

        public object GetValue()
        {
            return new Collection<string>() {GetString(), GetString()};
        }
    }
}
