using Xunit;

namespace SluggyUnidecode.Tests
{
    public class SluggyUnidecodeIntegrationTests
    {
        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Convert ToSlug With Unidecode")]
        [InlineData("ČŽŠ čžš", "czs-czs")]
        [InlineData("ア α a A", "a-a-a-a")]
        [InlineData("Hello, World!", "hello,-world!")]
        [InlineData("ä ö ű ő Ä Ö Ũ Ő", "ae-oe-u-o-ae-oe-u-o")]
        [InlineData("eu Não gosto de Pão da avó", "eu-nao-gosto-de-pao-da-avo")]
        [InlineData("Работа с кириллицей", "rabota-s-kirillitsey")]
        [InlineData("Мне нравится татарин", "mne-nravitsya-tatarin")]
        [InlineData("ch\u00e2teau Vi\u00f1edos", "chateau-vinedos")]
        [InlineData("", "")]
        public void ShouldConvertToSlugWithUnidecode(string value, string expectation)
        {
            var slugified = value.ToSlug();

            Assert.Equal(expectation, slugified);
        }
    }
}