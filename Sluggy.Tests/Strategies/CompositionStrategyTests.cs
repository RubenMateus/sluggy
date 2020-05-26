using Moq;
using Sluggy.Strategies;
using System.Linq;
using Xunit;

namespace Sluggy.Tests
{
    public class CompositionStrategyTests
    {
        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "Should Maintain the Strategies Order")]
        public void MaintainsOrder()
        {
            const int numberOfStrategies = 30;
            const string initialValue = "0";

            var strategies = Enumerable
                .Repeat(0, numberOfStrategies)
                .Select((t, index) =>
                {
                    var mock = new Mock<ITranslationStrategy>();
                    var indexString = index.ToString();

                    mock.Setup(strat => strat.Translate(indexString))
                        .Returns<string>(text => (int.Parse(text) + 1).ToString());

                    return mock;
                })
                .ToList();

            var composite = new CompositeStrategy(strategies.Select(t => t.Object));

            composite.Translate(initialValue);

            var assertionIndex = 0;
            foreach (var curr in strategies)
            {
                curr.Verify(t => t.Translate(assertionIndex.ToString()), Times.Once);
                assertionIndex++;
            }
        }

        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "Should Execute All Strategies")]
        public void AllStrategiesAreExecuted()
        {
            const int numberOfStrategies = 30;
            const string textValue = "Dummy";

            var strategies = Enumerable
                .Repeat(0, numberOfStrategies)
                .Select(t =>
                {
                    var mock = new Mock<ITranslationStrategy>();

                    mock
                        .Setup(strat => strat.Translate(textValue))
                        .Returns(textValue);

                    return mock;
                })
                .ToList();

            var composite = new CompositeStrategy(strategies.Select(t => t.Object));

            composite.Translate(textValue);

            foreach (var curr in strategies)
            {
                curr.Verify(t => t.Translate(textValue), Times.Once);
            }
        }
    }
}