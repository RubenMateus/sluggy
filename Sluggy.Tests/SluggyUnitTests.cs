using Moq;
using Sluggy.Strategies;
using System;
using Xunit;

namespace Sluggy.Tests
{
    public class SluggyUnitTests
    {
        [Trait("Project", "Sluggy")]
        [Fact(DisplayName = "ToSlug Should Throw ArgumentNullException")]
        public void ShouldThrowNullArgumentException()
        {
            const string text = null;

            Assert.Throws<ArgumentNullException>(() => text.ToSlug());
        }

        [Trait("Project", "Sluggy")]
        [Theory(DisplayName = "Should Return ToSlug With Mocked Translate")]
        [InlineData("EU GOSTO DE TÁRTE", "tarte-tarte-tarte-tarte")]
        [InlineData("EU GOSTO", "tarte-tarte")]
        [InlineData("EU não GOSTO", "tarte-tarte-tarte")]
        public void ShouldReturnSlugifiedWithMocked(string value, string expectation)
        {
            const string translated = "tarte";

            var strategyMock = new Mock<ITranslationStrategy>();
            strategyMock
                .Setup(t => t.Translate(It.IsAny<string>()))
                .Returns<string>(t => translated);

            var result = value.ToSlug(strategyMock.Object);

            Assert.Equal(expectation, result);
        }
    }
}