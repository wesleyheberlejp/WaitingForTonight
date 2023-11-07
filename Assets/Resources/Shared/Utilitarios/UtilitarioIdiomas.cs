using System;
using System.Linq;

public static class UtilitarioIdiomas
{

    public static IdiomasEnum Tipo(this string str)
    {
        IdiomasEnum idiomaLocalizado = IdiomasEnum.PortuguesBr;

        foreach (IdiomasEnum idioma in Enum.GetValues(typeof(IdiomasEnum)))
        {
            if (idioma.Sigla() == str)
            {
                idiomaLocalizado = idioma;
                break;
            }
        }
        return idiomaLocalizado;
    }
    public static string Traduzir(this string str, IdiomasEnum idioma)
    {
        var traducoes = IntroducaoCenaControlador.Intro.Game.Repositorio.Dicionario.ObterTraducoes();
        var dicionario = traducoes.Where(p => p.Contem(str))?.FirstOrDefault();
        var traducao = dicionario?.Traducao(idioma);

        return traducao == "" || traducao == null ? str : traducao;
    }

    public static string Traduzir(this string str, string idioma)
    {
        return Traduzir(str, Tipo(idioma));
    }

    public static string Traduzir(this string str)
    {
        var idioma = IntroducaoCenaControlador.Intro.Game.Repositorio.Configuracoes.Idioma;
        return Traduzir(str, idioma);
    }

    public static string Sigla(this IdiomasEnum idioma)
    {
        string valor;
        switch (idioma)
        {
            case IdiomasEnum.PortuguesPt:
                valor = "PT-PT";
                break;
            case IdiomasEnum.InglesUs:
                valor = "EN-US";
                break;
            case IdiomasEnum.EspanholEs:
                valor = "ES";
                break;
            case IdiomasEnum.FrancesFr:
                valor = "FR-BE";
                break;
            case IdiomasEnum.RussoRu:
                valor = "RU";
                break;
            case IdiomasEnum.AlemaoDe:
                valor = "DE";
                break;
            case IdiomasEnum.JaponesJa:
                valor = "JA";
                break;
            default:
                valor = "PT-BR";
                break;
        }
        return valor;
    }

    public static string PorExtenso(this IdiomasEnum idioma)
    {
        string valor;
        switch (idioma)
        {
            case IdiomasEnum.PortuguesPt:
                valor = "Português Portugal";
                break;
            case IdiomasEnum.InglesUs:
                valor = "English";
                break;
            case IdiomasEnum.EspanholEs:
                valor = "Español";
                break;
            case IdiomasEnum.FrancesFr:
                valor = "Français";
                break;
            case IdiomasEnum.RussoRu:
                valor = "Русский";
                break;
            case IdiomasEnum.AlemaoDe:
                valor = "Deutsch";
                break;
            case IdiomasEnum.JaponesJa:
                valor = "日本語";
                break;
            default:
                valor = "Português Brasil";
                break;
        }
        return valor;
    }
}

