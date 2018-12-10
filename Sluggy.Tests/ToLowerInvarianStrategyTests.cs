using System;
using Xunit;

namespace Sluggy.Tests
{
    public class ToLowerInvarianStrategyTests
    {
        [Trait("Project", "Sluggy")]
        [Theory(DisplayName = "Should LowerCase With InvariantCulture")]
        [InlineData("AbcDEf", "abcdef")]
        [InlineData("GHIJKL", "ghijkl")]
        public void ShouldLowerCaseWithInvariantCulture(string value, string expectation)
        {
            var strategy = new ToLowerInvariantStrategy();

            var translated = strategy.Translate(value);

            Assert.Equal(expectation, translated);
        }

        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "ToLowerInvariantStrategy Should Throw NullArgumentException")]
        public void ShouldThrowNullArgumentException()
        {
            const string cena = null;
            var strategy = new ToLowerInvariantStrategy();

            Assert.Throws<ArgumentNullException>(() => strategy.Translate(cena));
        }
    }
}