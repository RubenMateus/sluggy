using Xunit;

namespace SluggyUnidecode.Tests
{
    public class UnidecodeStrategyUnitTests
    {
        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Normalize With Unidecode")]
        [InlineData("\u5317\u4EB0", "Bei Jing ")]
        [InlineData("eu Não gosto de Pão da Avó", "eu Nao gosto de Pao da Avo")]
        [InlineData("э ю я", "e yu ya")]
        [InlineData("ф х ц ч ш щ", "f kh ts ch sh shch")]
        [InlineData("ä ö ü ß Ä Ö Ü ẞ", "ae oe ue ss Ae Oe Ue Ss")]
        public void ShouldNormalizeWithUnidecode(string value, string expectation)
        {
            var strategy = new UnidecodeStrategy();

            var translated = strategy.Translate(value);

            Assert.Equal(expectation, translated);
        }
    }
}