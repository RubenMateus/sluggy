using System;
using Xunit;

namespace SluggyUnidecode.Tests
{
    public class UnidecodeStrategyUnitTests
    {
        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Normalize With Unidecode")]
        [InlineData("\u5317\u4EB0", "Bei Jing ")]
        [InlineData("eu Não gosto de Pão da Avó", "eu Nao gosto de Pao da Avo")]
        [InlineData("э ю я", "e iu ia")]
        [InlineData("ф х ц ч ш щ", "f kh ts ch sh shch")]
        [InlineData("ä ö ü ß Ä Ö Ü ẞ", "a o u ss A O U Ss")]
        [InlineData("pijamalı hasta yağız şoföre çabucak güvendi", "pijamali hasta yagiz sofore cabucak guvendi")]
        [InlineData("もひとつ の せかい え", "mohitotsu no sekai e")]
        public void ShouldNormalizeWithUnidecode(string value, string expectation)
        {
            var strategy = new UnidecodeStrategy();

            var translated = strategy.Translate(value);

            Assert.Equal(expectation, translated);
        }

        [Trait("Project", "SluggyUnidecode")]
        [Fact(DisplayName = "UnidecodeStrategy Should Throw ArgumentNullException")]
        public void ShouldThrowNullArgumentException()
        {
            const string text = null;

            var strategy = new UnidecodeStrategy();

            Assert.Throws<ArgumentNullException>(() => strategy.Translate(text));
        }
    }
}