using System;
using Moq;
using Xunit;

namespace Sluggy.Tests
{
    public class SluggyUnitTests
    {
        [Fact]
        public void NullString_ShouldThrowNullArgumentException()
        {
            const string cena = null;

            Assert.Throws<ArgumentNullException>(() => cena.ToSlug());
        }

        [Theory]
        [InlineData("EU GOSTO DE TÁRTE", "tarte-tarte-tarte-tarte")]
        [InlineData("EU GOSTO", "tarte-tarte")]
        public void Banana_ShouldThrowNullArgumentException(string value, string exepectation)
        {
            const string translated = "tarte";

            var strategyMock = new Mock<ITranslationStrategy>();
            strategyMock
                .Setup(t => t.Translate(It.IsAny<string>()))
                .Returns<string>(t => translated);

            var result = value.ToSlug(strategyMock.Object);

            Assert.Equal(exepectation, result);
        }
    }
}