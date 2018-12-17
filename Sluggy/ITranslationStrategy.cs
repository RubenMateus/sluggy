namespace Sluggy
{
    /// <summary>
    /// Exposes the translation strategy, which supports a "translation" over a text.
    /// Can be used to apply modifications to the passed text.
    /// </summary>
    public interface ITranslationStrategy
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The specific strategy translated text</returns>
        string Translate(string text);
    }
}