using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Generators
{
    public class ICollectionDateTimeGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(ICollection<DateTime>);

        public object GetValue()
        {
            return new Collection<DateTime>() {GetDateTime(), GetDateTime(), GetDateTime()};
        }
    }
}
