﻿using System;

namespace Generators
{
    public class FloatGenerator : BaseGenerator, IGenerator
    {
        public Type Type { get; } = typeof(float);

        public object GetValue()
        {
            return GetSingle();
        }
    }
}
