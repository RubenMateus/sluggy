using System;
using Sluggy.Strategies;
using Xunit;

namespace Sluggy.Tests
{
    public class NonAlphaNumericStrategyTests
    {
        [Trait("Project", "Sluggy")]
        [Theory(DisplayName = "Should remove nonalphanumeric characters from string")]
        [InlineData("<>*.,;´`'~^!#%$&/()=}{[]@£€§¨+|", "")]
        [InlineData("a<>*.,;´`'~^!#%$&/()=}{[]@£€§¨+|-ba", "aba")]
        [InlineData("", "")]
        public void ShouldNormalize(string value, string expectation)
        {
            var strategy = new NonAlphaNumericStrategy();

            var translated = strategy.Translate(value);

            Assert.Equal(expectation, translated);
        }

        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "NonAlphaNumericStrategy Should Throw ArgumentNullException")]
        public void ShouldThrowNullArgumentException()
        {
            const string text = null;

            var strategy = new NonAlphaNumericStrategy();

            Assert.Throws<ArgumentNullException>(() => strategy.Translate(text));
        }
    }
}