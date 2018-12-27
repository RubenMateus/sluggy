using System;
using Sluggy;
using Unidecode.NET;

namespace SluggyUnidecode
{
    /// <summary>
    /// The normalization used by SluggyUnidecode, using Unidecode.NET.
    /// </summary>
    public class UnidecodeStrategy : ITranslationStrategy
    {
        /// <summary>
        /// Normalizes the provided text using the normalization from Unidecode.NET.
        /// Transliterate Unicode string to ASCII string.
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translated text with the Unidecode.NET</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public string Translate(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return text.Unidecode();
        }
    }
}