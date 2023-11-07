using System.Collections.Generic;
using System.Linq;

public class ConfiguracaoController : BaseController<Configuracao>
{
    public ConfiguracaoController(string nomeBanco) : base(nomeBanco)
    {

    }

    public void Inserir(string secao, string identificador, string valor)
    {
        var configuracao = Obter(p => p.Secao == secao && p.Identificador == identificador)?.FirstOrDefault();

        if(configuracao == null)
        {
            configuracao = new Configuracao();
        }

        configuracao.Identificador = identificador;
        configuracao.Secao = secao;
        configuracao.Valor = valor;

        base.InserirOuAtualizar(configuracao);
    }

    public void Inserir(string secao, string identificador, bool valor)
    {
        Inserir(secao, identificador, UtilitarioConvert.BoolToString(valor));
    }

    public void Inserir(string secao, string identificador, int valor)
    {
        Inserir(secao, identificador, valor.ToString());
    }

    public string Obter(string secao, string identificador, string valorDefault = "")
    {
        var configuracao = base.Obter(p => p.Secao == secao && p.Identificador == identificador)?.FirstOrDefault();
        return (configuracao == null || configuracao.Valor == string.Empty) ? valorDefault : configuracao.Valor;
    }

    public bool Obter(string secao, string identificador, bool valorDefault = false)
    {
        var resultado = Obter(secao, identificador, UtilitarioConvert.BoolToString(valorDefault));
        return UtilitarioConvert.StringToBool(resultado) ;
    }
    public int Obter(string secao, string identificador, int valorDefault = 0)
    {
        int resultado;
        int.TryParse(Obter(secao, identificador, valorDefault.ToString()), out resultado);
        return resultado;
    }

}
