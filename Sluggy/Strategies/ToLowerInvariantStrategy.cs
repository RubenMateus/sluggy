using System;

namespace Sluggy.Strategies
{
    /// <summary>
    /// The standard ToLowerCase strategy used by Sluggy.
    /// </summary>
    public class ToLowerInvariantStrategy : ITranslationStrategy
    {
        /// <summary>
        /// Translates the text using ToLowerInvariant.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The translated text with toLowerInvariant.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public string Translate(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return text.ToLowerInvariant();
        }
    }
}