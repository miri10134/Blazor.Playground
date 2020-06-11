using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazor.Playground.Common.Util
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> enumerable)
            => enumerable == null ? new T[0] : enumerable;

        public static T[] IntoArray<T>(this T element)
            => new T[] { element };

        public static IList<T> IntoList<T>(this T element)
            => new List<T> { element };

        public static string Format<T>(this IEnumerable<T> enumerable, Func<T, string> generator = null)
        {
            return $"[{string.Join(", ", enumerable.NullToEmpty().Select(e => generator?.Invoke(e) ?? e?.ToString()))}]";
        }

        public static string Format<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Func<TKey, string> keyGenerator = null, Func<TValue, string> valueGenerator = null)
        {
            if (dictionary == null)
                return string.Empty;

            return $"{{{string.Join(" ", dictionary.Select(p => $"<{keyGenerator?.Invoke(p.Key) ?? p.Key?.ToString()} : {valueGenerator?.Invoke(p.Value) ?? p.Key?.ToString()}>")) }}}";
        }
    }
}
