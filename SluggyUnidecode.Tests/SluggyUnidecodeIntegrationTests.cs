using Xunit;

namespace SluggyUnidecode.Tests
{
    public class SluggyUnidecodeIntegrationTests
    {
        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Convert ToSlug With Unidecode")]
        [InlineData("ČŽŠ čžš", "czs-czs")]
        [InlineData("ア α a", "a-a-a")]
        [InlineData("ä ö ű ő Ä Ö Ũ Ő", "ae-oe-u-o-ae-oe-u-o")]
        [InlineData("eu não gosto de pão da avó", "eu-nao-gosto-de-pao-da-avo")]
        [InlineData("Работа с кириллицей", "rabota-s-kirillitsey")]
        [InlineData("ch\u00e2teau vi\u00f1edos", "chateau-vinedos")]
        public void ShouldConvertToSlugWithUnidecode(string value, string expectation)
        {
            var slugified = value.ToSlug();

            Assert.Equal(expectation, slugified);
        }
    }
}