using System;
using System.Collections.Generic;
using System.Linq;

namespace Sluggy
{
    public static class Sluggy
    {
        public static readonly string DefaultSeparator = "-";

        public static readonly ITranslationStrategy DefaultTranslationStrategy = new CompositeStrategy(
            new NormalizationStrategy(),
            new ToLowerCaseStrategy());

        public static string ToSlug(this string text)
        {
            return ToSlug(text, DefaultSeparator, DefaultTranslationStrategy);
        }

        public static string ToSlug(this string text, string separator)
        {
            return ToSlug(text, separator, DefaultTranslationStrategy);
        }

        public static string ToSlug(this string text, ITranslationStrategy strategy)
        {
            return ToSlug(text, DefaultSeparator, strategy);
        }

        public static string ToSlug(this string text, string separator, ITranslationStrategy strategy)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return text
                .Split()
                .Where(t => t.Length != 0)
                .Select(t => strategy.Translate(t))
                .Join(separator);
        }

        private static string Join(this IEnumerable<string> text, string separator)
        {
            return string.Join(separator, text);
        }
    }
}