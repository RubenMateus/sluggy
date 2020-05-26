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

        [Trait("Project", "SluggyUnidecode")]
        [Theory(DisplayName = "Should Convert ToSlug With Unidecode and Separator")]
        [InlineData("ČŽŠ čžš", "czs_czs", "_")]
        [InlineData("ア α a A", "a_a_a_a", "_")]
        [InlineData("Hello, World!", "hello_world", "_")]
        [InlineData("ä ö ű ő Ä Ö Ũ Ő", "a_o_u_o_a_o_u_o", "_")]
        [InlineData("eu Não gosto de Pão da avó", "eu_nao_gosto_de_pao_da_avo", "_")]
        [InlineData("Работа с кириллицей", "rabota_s_kirillitsei", "_")]
        [InlineData("Мне нравится татарин", "mne_nravitsia_tatarin", "_")]
        [InlineData("ch\u00e2teau Vi\u00f1edos", "chateau_vinedos", "_")]
        [InlineData("FAZLA ÇİKOLATA YEMEK DİŞ SAĞLIĞINI BOZABİLİR", "fazla_cikolata_yemek_dis_sagligini_bozabilir", "_")]
        [InlineData("Fazla çikolata yemek diş sağlığını bozabilir", "fazla_cikolata_yemek_dis_sagligini_bozabilir", "_")]
        [InlineData("PİJAMALI HASTA YAĞIZ ŞOFÖRE ÇABUCAK GÜVENDİ", "pijamali_hasta_yagiz_sofore_cabucak_guvendi", "_")]
        [InlineData("pijamalı hasta yağız şoföre çabucak güvendi", "pijamali_hasta_yagiz_sofore_cabucak_guvendi", "_")]
        [InlineData("1.10 もひとつ の せかい え", "110_mohitotsu_no_sekai_e", "_")]
        [InlineData("a    <>*.,;´`'~^!#%$&/    n     ()=}{[]@£€§¨+|  ºª    a", "a_n_oa_a", "_")]
        [InlineData("", "", "_")]
        public void ShouldConvertToSlugWithUnidecodeWithSeparator(string value, string expectation, string separator)
        {
            var slugified = value.ToSlug(separator);

            Assert.Equal(expectation, slugified);
        }
    }
}