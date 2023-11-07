using System;
using UnityEngine;

public class EmissorEvento_Service : MonoBehaviour
{
    public static event Action<string> MensagemEvento;
    public static event Action<TipoNotificacao_Enum> NotificacaoEvento;

    public static void EmiteMenssagem(string mensagem = null)
    {
        MensagemEvento?.Invoke(mensagem);
    }

    public static void EmiteMenssagem(TipoNotificacao_Enum tipoNotificacao)
    {
        NotificacaoEvento?.Invoke(tipoNotificacao);
    }

    public void EmiteMenssagemNaoEstatica(TipoNotificacao_Enum tipoNotificacao)
    {
        NotificacaoEvento?.Invoke(tipoNotificacao);
    }
}
