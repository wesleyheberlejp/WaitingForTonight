using UnityEngine;

public static class Versao_Servico
{
    public static string ObterVersaoDescricao()
    {
        return Application.version;
    }

    public static bool VersaoTeste()
    {
        return Versao().Build > 99;
    }

    public static Versao Versao()
    {

        var _versaoDescricao = ObterVersaoDescricao().Split('.');

        int _dia = 0;
        int _build = 0;
        int _mes = 0;
        int _ano = 0;

        int[] numeros = new int[4];

        if (_versaoDescricao.Length >= 1)
            int.TryParse(_versaoDescricao[0], out _ano);
        if (_versaoDescricao.Length >= 2)
            int.TryParse(_versaoDescricao[1], out _mes);
        if (_versaoDescricao.Length >= 3)
            int.TryParse(_versaoDescricao[2], out _dia);
        if (_versaoDescricao.Length >= 4)
            int.TryParse(_versaoDescricao[3], out _build);

        var _versao = new Versao(_dia, _mes, _ano, _build);

        return _versao;
    }

    public static string Descricao()
    {
        var descricaoVersao = ObterVersaoDescricao();
        var versao = Versao();

        if (VersaoTeste())
        {
            descricaoVersao = descricaoVersao + " - Versão de testes";
        }

        return descricaoVersao;

    }

}
