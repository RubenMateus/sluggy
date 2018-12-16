using System.Collections.Generic;

namespace Sluggy
{
    /// <summary>
    ///
    /// </summary>
    public class CompositeStrategy : ITranslationStrategy
    {
        private readonly IEnumerable<ITranslationStrategy> _strategies;

        /// <summary>
        ///
        /// </summary>
        /// <param name="strategies"></param>
        public CompositeStrategy(params ITranslationStrategy[] strategies)
            : this((IEnumerable<ITranslationStrategy>)strategies)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="strategies"></param>
        public CompositeStrategy(IEnumerable<ITranslationStrategy> strategies)
        {
            _strategies = strategies;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translated text with the conjuction of the different passed strategies</returns>
        public string Translate(string text)
        {
            var translated = text;

            foreach (var curr in _strategies)
            {
                translated = curr.Translate(translated);
            }

            return translated;
        }
    }
}