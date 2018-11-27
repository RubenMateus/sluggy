using System;
using System.Collections.Generic;
using System.Linq;

namespace Sluggy
{
    public static class Sluggy
    {
        public static string ToSlug(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var sluggy = text
                .LazySplit()
                .Where(t => t.Any())
                .LazyJoin()
                .ToArray();

            return new string(sluggy);
        }

        private static IEnumerable<IEnumerable<char>> LazySplit(this IEnumerable<char> chars)
        {
            var currList = Enumerable.Empty<char>();
            foreach (var curr in chars)
            {
                if (char.IsWhiteSpace(curr))
                {
                    yield return currList;

                    currList = Enumerable.Empty<char>();
                }
                else
                {
                    currList = currList.Concat(curr.ToEnumerable());
                }
            }
        }

        private static IEnumerable<T> ToEnumerable<T>(this T instance)
        {
            yield return instance;
        }

        private static IEnumerable<char> LazyJoin(this IEnumerable<IEnumerable<char>> chars, IEnumerable<char> separator = "-")
        {
            var enumerator = chars.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                yield break;
            }

            foreach (var currChar in enumerator.Current)
            {
                yield return currChar;
            }

            while (enumerator.MoveNext())
            {
                foreach (var currChar in separator)
                {
                    yield return currChar;
                }

                foreach (var currChar in enumerator.Current)
                {
                    yield return currChar;
                }
            }
        }
    }
}