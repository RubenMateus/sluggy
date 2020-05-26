using Sluggy;
using Sluggy.Strategies;
using System;

namespace SluggyUnidecode
{
    /// <summary>
    /// Exposes the toSlug extension method, gives support to
    /// transform regular strings into friendly urls using the Unidecode translation.
    /// </summary>
    public static class SluggyUnidecode
    {
        /// <summary>
        /// The UnidecodeStrategy which aggregates the
        /// ToLowerInvariantStrategy and UnidecodeStrategy.
        /// This is the composite strategy used by default in the SluggyUnidecode.
        /// </summary>
        public static readonly ITranslationStrategy UnidecodeStrategy = new CompositeStrategy(
            new NonAlphaNumericStrategy(),
            new UnidecodeStrategy(),
            new ToLowerInvariantStrategy());

        /// <summary>
        /// Transforms the passed text into a friendly url or name (slug)
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The text transformed into a friendly url (slug).</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public static string ToSlug(this string text) => text.ToSlug(UnidecodeStrategy);

        /// <summary>
        /// Transforms the passed text into a friendly url or name (slug)
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <param name="separator">The separator to be used.</param>
        /// <returns>The text transformed into a friendly url (slug).</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public static string ToSlug(this string text, string separator) => text.ToSlug(separator, UnidecodeStrategy);
    }
}