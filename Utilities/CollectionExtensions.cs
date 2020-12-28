using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class CollectionExtensions
    {
        public static IList<T> ToListFromItem<T>(this T item)
        {
            return new List<T> { item };
        }
    }
}
