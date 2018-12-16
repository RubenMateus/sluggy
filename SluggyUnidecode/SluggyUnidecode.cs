using Sluggy;

namespace SluggyUnidecode
{
    /// <summary>
    ///
    /// </summary>
    public static class SluggyUnidecode
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly ITranslationStrategy UnidecodeStrategy = new CompositeStrategy(
            new UnidecodeStrategy(),
            new ToLowerInvariantStrategy());

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSlug(this string text)
        {
            return text.ToSlug(UnidecodeStrategy);
        }
    }
}