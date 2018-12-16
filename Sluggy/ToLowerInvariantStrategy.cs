using System;

namespace Sluggy
{
    /// <summary>
    ///
    /// </summary>
    public class ToLowerInvariantStrategy : ITranslationStrategy
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translated text with toLowerInvariant method</returns>
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