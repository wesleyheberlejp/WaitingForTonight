using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AtualizacaoScriptGameController : ConfiguracaoController
{
    public AtualizacaoScriptGameController(string nomeBanco) : base(nomeBanco)
    {
       
    }
    private void Inserir(string nomeScript, bool Atualizado = true)
    {
        base.Inserir("ATUALIZAÇÃO", nomeScript, Atualizado);
    }

    public void Inserir(Script script, bool Atualizado = true)
    {
        Inserir(script.Nome, Atualizado);
    }

    private bool Obter(string nomeScript)
    {
        return base.Obter("ATUALIZAÇÃO", nomeScript, false);
    }

    public bool Obter(Script script)
    {
        return Obter(script.Nome);
    }

    public List<Configuracao> ObterScriptsAtualizados()
    {
        return base.Obter(p => p.Secao == "ATUALIZAÇÃO" && p.Valor == "T");
    }

}
