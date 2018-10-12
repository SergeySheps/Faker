﻿using System;

namespace Generators
{
    public class Int64Generator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(Int64);

        public object GetValue()
        {
            return GetInt64();
        }
    }
}
