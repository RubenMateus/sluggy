using System;
using System.Collections.Generic;
using System.Linq;

namespace Sluggy
{
    /// <summary>
    ///
    /// </summary>
    public static class Sluggy
    {
        private const string DefaultSeparator = "-";

        /// <summary>
        ///
        /// </summary>
        public static readonly ITranslationStrategy DefaultTranslationStrategy = new CompositeStrategy(
            new ToLowerInvariantStrategy(),
            new NormalizationStrategy());

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSlug(this string text) => ToSlug(text, DefaultSeparator, DefaultTranslationStrategy);

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToSlug(this string text, string separator) => ToSlug(text, separator, DefaultTranslationStrategy);

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public static string ToSlug(this string text, ITranslationStrategy strategy) => ToSlug(text, DefaultSeparator, strategy);

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <param name="strategy"></param>
        /// <returns></returns>
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

        private static string Join(this IEnumerable<string> text, string separator) => string.Join(separator, text);
    }
}