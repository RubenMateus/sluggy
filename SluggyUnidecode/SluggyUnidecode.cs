using Sluggy;

namespace SluggyUnidecode
{
    public static class SluggyUnidecode
    {
        public static readonly ITranslationStrategy UnidecodeStrategy = new CompositeStrategy(
            new UnidecodeStrategy(),
            new ToLowerInvariantStrategy());

        public static string ToSlug(this string text)
        {
            return text.ToSlug(UnidecodeStrategy);
        }
    }
}