using UnityEngine;

public class ManagerBase
{
    [HideInInspector]
    protected string NomeBancoDados;
    public AtualizacaoScriptGameController Atualizacao;
    public DicionarioController Dicionario;
    public ConfiguracoesGameController Configuracoes;

    protected void DefinirInstanciaControllersBase()
    {
        Configuracoes = new ConfiguracoesGameController(NomeBancoDados);
        Atualizacao = new AtualizacaoScriptGameController(NomeBancoDados);
        Dicionario = new DicionarioController(NomeBancoDados);
    }

    public ManagerBase(string nomeDB)
    {
        this.NomeBancoDados = nomeDB;
        DefinirInstanciaControllersBase();
    }
}
