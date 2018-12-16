using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sluggy
{
    /// <summary>
    ///
    /// </summary>
    public class NormalizationStrategy : ITranslationStrategy
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translated text with the normalization FormD</returns>
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