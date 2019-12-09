namespace TextRazor.Net.Extensions
{
    using System.Collections.Generic;

    internal static class Extensions
    {
        public static void Add<T1, T2>(this ICollection<KeyValuePair<T1, T2>> col, T1 key, T2 value)
        {
            col.Add(new KeyValuePair<T1, T2>(key, value));
        }
    }
}