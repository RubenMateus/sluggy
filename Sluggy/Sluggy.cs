using System;
using System.Collections.Generic;
using System.Linq;

namespace Sluggy
{
    /// <summary>
    /// Exposes the toSlug extension method, gives support to
    /// transform regular strings into friendly urls.
    /// </summary>
    public static class Sluggy
    {
        /// <summary>
        /// The default separator used by Sluggy.
        /// </summary>
        public static readonly string DefaultSeparator = "-";

        /// <summary>
        /// The DefaultTranslationStrategy which aggregates the
        /// ToLowerInvariantStrategy and NormalizationStrategy.
        /// This is the composite strategy used by default.
        /// </summary>
        public static readonly ITranslationStrategy DefaultTranslationStrategy = new CompositeStrategy(
            new ToLowerInvariantStrategy(),
            new NormalizationStrategy());

        /// <summary>
        /// Transforms the passed text into a friendly url (slug)
        /// using the default Separator "-" and the DefaultTranslationStrategy.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The text transformed into a friendly url (slug).</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public static string ToSlug(this string text) => ToSlug(text, DefaultSeparator, DefaultTranslationStrategy);

        /// <summary>
        /// Transforms the passed text into a friendly url (slug)
        /// using the provided Separator and the DefaultTranslationStrategy.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <param name="separator">The separator to be used when encoutering whitespaces.</param>
        /// <returns>The text transformed into a friendly url (slug) using the provided separator.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public static string ToSlug(this string text, string separator) => ToSlug(text, separator, DefaultTranslationStrategy);

        /// <summary>
        /// Transforms the passed text into a friendly url (slug)
        /// using the default Separator "-" and the provided Strategy or Strategies.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <param name="strategy">The strategy or strategies to provide extra transformations.</param>
        /// <returns>The text transformed into a friendly url (slug) using the provided separator.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public static string ToSlug(this string text, ITranslationStrategy strategy) => ToSlug(text, DefaultSeparator, strategy);

        /// <summary>
        /// Transforms the passed text into a friendly url (slug)
        /// using the provided Separator and the provided Strategy or Strategies.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <param name="separator">The separator to be used when encoutering whitespaces.</param>
        /// <param name="strategy">The strategy or strategies to provide extra transformations.</param>
        /// <returns>The text transformed into a friendly url (slug) using the provided separator and strategies.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
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