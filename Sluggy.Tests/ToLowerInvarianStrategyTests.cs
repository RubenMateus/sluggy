using Xunit;

namespace Sluggy.Tests
{
    public class ToLowerInvarianStrategyTests
    {
        [Fact]
        public void LowersCaseWithInvarianCulture()
        {
            var strategy = new ToLowerInvariantStrategy();

            var translated = strategy.Translate("AbcDEf");

            Assert.Equal("abcdef", translated);
        }
    }
}
