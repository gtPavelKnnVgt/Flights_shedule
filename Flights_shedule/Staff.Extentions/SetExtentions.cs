﻿using System.Collections.Generic;

namespace Staff.Extentions
{
    public static class SetExtensions
    {
        public static bool? TryAdd<T>(this ISet<T> set, T value)
            where T : class
        {
            return value is null
                ? null : (bool?)
                set.Add(value);
        }
    }
}
