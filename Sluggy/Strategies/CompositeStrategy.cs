using System.Collections.Generic;

namespace Sluggy.Strategies
{
    /// <summary>
    /// The composite strategy to agreggate all the different ITranslationStrategies from Sluggy.
    /// </summary>
    public class CompositeStrategy : ITranslationStrategy
    {
        private readonly IEnumerable<ITranslationStrategy> _strategies;

        /// <summary>
        /// BaseConstructor for passing the strategies as params to be iterated.
        /// </summary>
        /// <param name="strategies">The different types of strategies to be used.</param>
        public CompositeStrategy(params ITranslationStrategy[] strategies)
            : this((IEnumerable<ITranslationStrategy>)strategies)
        {
        }

        /// <summary>
        /// Overload of BaseConstructor for passing the strategies as IEnumerable to be iterated.
        /// </summary>
        /// <param name="strategies">The different types of strategies to be used.</param>
        public CompositeStrategy(IEnumerable<ITranslationStrategy> strategies)
        {
            _strategies = strategies;
        }

        /// <summary>
        /// Iterates throught all the strategies and translates the text using all the strategies passed.
        /// </summary>
        /// <param name="text">The text to be translated.</param>
        /// <returns>The translated text with the conjuction of the different passed strategies.</returns>
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