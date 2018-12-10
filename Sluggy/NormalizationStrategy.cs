using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sluggy
{
    public class NormalizationStrategy : ITranslationStrategy
    {
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