using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BancoDadosAtualizadorControlador : BancoDadosControlador
{

    public int UltimaVersaoAtualizada { get => ObterVersaoBaseDados(); }
    private List<Script> listaScripts;

    private void DefinirListaEstruturasPadroes()
    {
        const string PastaScritpsAtualizacaoBase = "Shared/BancoDados/Atualização";
        listaScripts = new List<Script>();

        var listaArquivos = PastaScritpsAtualizacaoBase.ObterArquivos();

        foreach (var item in listaArquivos)
        {
            if (item.ToString() != null)
            {
                listaScripts.Add(new Script { Nome = item.name, Arquivo = item.ToString() });
            }
        }
    }

    public int ObterVersaoBaseDados()
    {
        int version;
        Conexao.Query.CommandText = "PRAGMA user_version;";
        try
        {
            version = Convert.ToInt32(Conexao.Query.ExecuteScalar());
        }
        catch (Exception)
        {
            version = 0;
        }

        return version;
    }

    public void DefinirDatabaseVersion(int version)
    {
        Conexao.Query.CommandText = $"PRAGMA user_version = {version};";
        Conexao.Query.ExecuteNonQuery();
    }

    public void ExecuteScriptFromFile(TextAsset script, int versao)
    {
        Conexao.Query.CommandText = script.ToString();
        if (Conexao.Query.CommandText != string.Empty)
        {
            Conexao.Query.ExecuteNonQuery();
            DefinirDatabaseVersion(versao);
        }
    }

    public void ExecuteScriptFromFile(Script script)
    {
        Conexao.Query.CommandText = script.Arquivo.ToString();
        if (Conexao.Query.CommandText != string.Empty)
        {
            Conexao.Query.ExecuteNonQuery();
            IntroducaoCenaControlador.Intro.Game.Repositorio.Atualizacao.Inserir(script);
        }
    }

    private void AtualizarScriptsEstruturasBases()
    {
        DefinirListaEstruturasPadroes();

        var scriptsAtualizados = IntroducaoCenaControlador.Intro.Game.Repositorio.Atualizacao.ObterScriptsAtualizados();

        foreach (var script in listaScripts)
        {
            if (scriptsAtualizados == null)
            {
                ExecuteScriptFromFile(script);
            }
            else
            {
                if (!scriptsAtualizados.Any(p => p.Identificador.Contains(script.Nome)))
                {
                    ExecuteScriptFromFile(script);
                }
            }
        }
    }

    public virtual void Atualizar()
    {
        AtualizarScriptsEstruturasBases();
    }
}