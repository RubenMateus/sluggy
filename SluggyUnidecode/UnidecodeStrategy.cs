using Sluggy;
using System;
using Unidecode.NET;

namespace SluggyUnidecode
{
    /// <summary>
    ///
    /// </summary>
    public class UnidecodeStrategy : ITranslationStrategy
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translated text with the Unidecode.NET</returns>
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