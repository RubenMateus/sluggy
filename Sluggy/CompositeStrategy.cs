using System.Collections.Generic;

namespace Sluggy
{
    public class CompositeStrategy : ITranslationStrategy
    {
        private readonly IEnumerable<ITranslationStrategy> _strategies;

        public CompositeStrategy(params ITranslationStrategy[] strategies)
            : this((IEnumerable<ITranslationStrategy>)strategies)
        {
        }

        public CompositeStrategy(IEnumerable<ITranslationStrategy> strategies)
        {
            _strategies = strategies;
        }

        public string Translate(string text)
        {
            var translated = text;

            foreach (var curr in _strategies)
            {
                translated = curr.Translate(text);
            }

            return translated;
        }
    }
}