using Xunit;

namespace Sluggy.Tests
{
    public class SluggyIntegrationTests
    {
        [Theory]
        [InlineData("EU GOSTO DE TÁRTE", "euAgostoAdeAtarte", "A")]
        [InlineData("EU GOSTO", "euBananagosto", "Banana")]
        public void ShouldUseSeparator(string value, string expectation, string separator)
        {
            var result = value.ToSlug(separator);

            Assert.Equal(expectation, result);
        }

        [Theory]
        [InlineData("EU GOSTO DE TÁRTE", "eu-gosto-de-tarte")]
        [InlineData("eu gosto de tarte        das", "eu-gosto-de-tarte-das")]
        [InlineData("eu gosto de tarte", "eu-gosto-de-tarte")]
        [InlineData("eu não gosto de pão da avó", "eu-nao-gosto-de-pao-da-avo")]
        [InlineData("", "")]
        public void ShouldConvertToSlug(string value, string expectation)
        {
            var slugified = value.ToSlug();

            Assert.Equal(expectation, slugified);
        }
    }
}