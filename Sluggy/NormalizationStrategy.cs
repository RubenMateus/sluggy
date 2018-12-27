using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sluggy
{
    /// <summary>
    /// The standard normalization used by Sluggy.
    /// </summary>
    public class NormalizationStrategy : ITranslationStrategy
    {
        /// <summary>
        /// Normalizes the provided text using the Normalization.FormD,
        /// which indicates that a unicode string is normalized using full canonical decomposition.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The translated text with the normalization FormD.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public string Translate(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            return string
                .Concat(text
                    .Normalize(NormalizationForm.FormD)
                    .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
        }
    }
}