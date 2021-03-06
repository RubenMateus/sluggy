﻿using System;
using System.Linq;

namespace Sluggy.Strategies
{
    /// <summary>
    /// The standard NonAlphaNumeric Strategy used by Sluggy.
    /// </summary>
    public class NonAlphaNumericStrategy : ITranslationStrategy
    {
        /// <summary>
        /// This strategy is used for removing non alpha numeric characters from the provided text.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The transformed text.</returns>
        /// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
        public string Translate(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var nonAlphaNumericChars = text.Where(c =>
                char.IsLetterOrDigit(c) ||
                char.IsWhiteSpace(c))
                .ToArray();

            return new string(nonAlphaNumericChars);
        }
    }
}