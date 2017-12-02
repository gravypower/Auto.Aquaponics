using System.Collections.Generic;
using System.Linq;

namespace Ponics.Kernel.Extensions
{
    public static class Strings
    {
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()) + "}";
        }

        public static string ToDebugString<TType>(this ICollection<TType> list)
        {
            return string.Join(", ", list.ToArray());
        }
    }
}
