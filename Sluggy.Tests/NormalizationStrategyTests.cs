using System;
using Xunit;

namespace Sluggy.Tests
{
    public class NormalizationStrategyTests
    {
        [Trait("Project", "Sluggy")]
        [Theory(DisplayName = "Should Normalize string")]
        [InlineData("áãâàóôòõêè", "aaaaooooee")]
        [InlineData("ä ö ű ő", "a o u o")]
        public void ShouldNormalize(string value, string expectation)
        {
            var strategy = new NormalizationStrategy();

            var translated = strategy.Translate(value);

            Assert.Equal(expectation, translated);
        }

        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "NormalizationStrategy Should Throw NullArgumentException")]
        public void ShouldThrowNullArgumentException()
        {
            const string text = null;

            var strategy = new NormalizationStrategy();

            Assert.Throws<ArgumentNullException>(() => strategy.Translate(text));
        }
    }
}