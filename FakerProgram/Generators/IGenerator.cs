using System;

namespace Generators
{
    public interface IGenerator
    {
        Type Type { get; }
        object GetValue();
    }
}
