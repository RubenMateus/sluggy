using Xunit;

namespace Sluggy.Tests
{
    public class SluggyTests
    {
        [Fact]
        public void SimpleString_ShouldConvertToSimpleSlug()
        {
            const string cena = "eu gosto de tarte";

            var slugified = cena.ToSlug();

            Assert.Equal("eu-gosto-de-tarte", slugified);
        }

        [Fact]
        public void ComplexString_ShouldConvertToSimpleSlug()
        {
            const string cena = "eu não gosto de pão da avó";

            var slugified = cena.ToSlug();

            Assert.Equal("eu-nao-gosto-de-pao-da-avo", slugified);
        }
    }
}