using Xunit;

namespace SluggyUnidecode.Tests
{
    public class SluggyUnidecodeIntegrationTests
    {
        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Convert ToSlug With Unidecode")]
        [InlineData("ČŽŠ čžš", "czs-czs")]
        [InlineData("ア α a A", "a-a-a-a")]
        [InlineData("Hello, World!", "hello-world")]
        [InlineData("ä ö ű ő Ä Ö Ũ Ő", "a-o-u-o-a-o-u-o")]
        [InlineData("eu Não gosto de Pão da avó", "eu-nao-gosto-de-pao-da-avo")]
        [InlineData("Работа с кириллицей", "rabota-s-kirillitsei")]
        [InlineData("Мне нравится татарин", "mne-nravitsia-tatarin")]
        [InlineData("ch\u00e2teau Vi\u00f1edos", "chateau-vinedos")]
        [InlineData("FAZLA ÇİKOLATA YEMEK DİŞ SAĞLIĞINI BOZABİLİR", "fazla-cikolata-yemek-dis-sagligini-bozabilir")]
        [InlineData("Fazla çikolata yemek diş sağlığını bozabilir", "fazla-cikolata-yemek-dis-sagligini-bozabilir")]
        [InlineData("PİJAMALI HASTA YAĞIZ ŞOFÖRE ÇABUCAK GÜVENDİ", "pijamali-hasta-yagiz-sofore-cabucak-guvendi")]
        [InlineData("pijamalı hasta yağız şoföre çabucak güvendi", "pijamali-hasta-yagiz-sofore-cabucak-guvendi")]
        [InlineData("1.10 もひとつ の せかい え", "110-mohitotsu-no-sekai-e")]
        [InlineData("a    <>*.,;´`'~^!#%$&/    n     ()=}{[]@£€§¨+|  ºª    a", "a-n-oa-a")]
        [InlineData("", "")]
        public void ShouldConvertToSlugWithUnidecode(string value, string expectation)
        {
            var slugified = value.ToSlug();

            Assert.Equal(expectation, slugified);
        }
    }
}