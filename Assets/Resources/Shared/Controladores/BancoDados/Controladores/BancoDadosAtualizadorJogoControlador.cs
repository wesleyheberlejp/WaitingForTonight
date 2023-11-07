using System.Collections.Generic;
using UnityEngine;

public class BancoDadosAtualizadorJogoControlador : BancoDadosAtualizadorControlador
{

    [SerializeField]
    private List<TextAsset> EstruturasJogo;

    public override void Atualizar()
    {
        base.Atualizar();

        foreach (var script in EstruturasJogo)
        {
            int _versao = EstruturasJogo.IndexOf(script);
            _versao++;
            if (UltimaVersaoAtualizada < _versao)
            {
                ExecuteScriptFromFile(script, _versao);
            }
        }
    }

    void Start()
    {
        Atualizar();
    }

}