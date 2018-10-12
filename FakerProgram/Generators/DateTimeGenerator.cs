using System;

namespace Generators
{
    public class DateTimeGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(DateTime);

        public object GetValue()
        {
            return GetDateTime();
        }
    }
}
