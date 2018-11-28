namespace Sluggy
{
    public class ToLowerCaseStrategy : ITranslationStrategy
    {
        public string Translate(string text)
        {
            return text.ToLowerInvariant();
        }
    }
}