using Sluggy;
using Unidecode.NET;

namespace SluggyUnidecode
{
    public class UnidecodeStrategy : ITranslationStrategy
    {
        public string Translate(string text) => text.Unidecode();
    }
}