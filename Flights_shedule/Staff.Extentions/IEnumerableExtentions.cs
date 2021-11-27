namespace Staff.Extentions
{
    using System.Collections.Generic;
    public static class IEnumerableExtentions
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator = ", ") =>
            string.Join(separator, collection);
    }
}
