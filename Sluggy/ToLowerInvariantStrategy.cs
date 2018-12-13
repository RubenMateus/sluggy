using System;

namespace Sluggy
{
    public class ToLowerInvariantStrategy : ITranslationStrategy
    {
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
