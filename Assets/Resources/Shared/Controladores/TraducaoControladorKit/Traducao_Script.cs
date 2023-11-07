using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Traducao_Script : MonoBehaviour
{
    [Header("Modo Preguiça (tenta encontrar a tradução no arquivo)")]
    public string FraseTraduzir;
    [Header("Modo Pro (Busca por uma key expecifica)")]
    public string KeyTraduzir;

    [Header("Cadastro")]
    public string Key = null;
    public string Valor = null;
    public string Idioma = null;
    public bool Cadastrar = false;

    internal TextMeshProUGUI LabelDestino;

    //private void Start()
    //{
    //    LabelDestino= GetComponent<TextMeshProUGUI>();

    //    if (KeyTraduzir != null && KeyTraduzir.Trim() != "")
    //    {
    //        LabelDestino.text = Traducoes_Controlador.Self.TraduzirByKey(KeyTraduzir.ToUpper());
    //    }else
    //    LabelDestino.text = Traducoes_Controlador.Self.Traduzir(FraseTraduzir.ToUpper());
    //}

    private void FixedUpdate()
    {
        if (Cadastrar) CadastrarKey();
    }

    public void CadastrarKey()
    {
        if(!string.IsNullOrEmpty(Key) || !string.IsNullOrEmpty(Valor) || !string.IsNullOrEmpty(Idioma))
        {
            Traducoes_Controlador.Self.CadastrarKey(Key, Valor, Idioma);
            Key= null;
            Valor= null;
            Idioma= null;
            Cadastrar= false;
        }
    }

    public void SetKeyTraducao(string Key)
    {
        LabelDestino.text = Traducoes_Controlador.Self.TraduzirByKey(Key.ToUpper());
    }
}
