using UnityEngine;

public class RondasControlador : MonoBehaviour
{
    public int QuantidadeInimigosEliminar = 3;
    public GameObject InimigosContainer;
    public GameObject SpawnsContainer;

    public float TimerNovaRonda = 5f;
    internal int RondaAtual;
    private int InimigosEliminadosRondaAtual = 0;
    private bool AtivaTimerNovaRonda;
    private float Temp_TimerNovaRonda = 5f;


    private void Awake()
    {
        AtivaTimerNovaRonda = true;
        EmissorEvento_Service.NotificacaoEvento += EscutaEventos;
    }

    private void FixedUpdate()
    {
        AplicaTimerNovaRonda();
    }

    private void AplicaTimerNovaRonda()
    {
        if (!AtivaTimerNovaRonda) return;
        Temp_TimerNovaRonda -= Time.fixedDeltaTime;

        if (Temp_TimerNovaRonda < 0)
            IniciarNovaRonda();
    }

    private void EscutaEventos(TipoNotificacao_Enum tipoNotificacao)
    {
        switch (tipoNotificacao) 
        {
            case TipoNotificacao_Enum.InimigoEliminado:
                InimigosEliminadosRondaAtual++;
                FinalizaRonda();
                break;
        }
    }

    public void IniciarNovaRonda()
    {
        RondaAtual ++;
        AtivaTimerNovaRonda = false;
        SpawnsContainer.SetActive(true);
    }

    public void FinalizaRonda()
    {
        if (InimigosEliminadosRondaAtual < QuantidadeInimigosEliminar) return;

        SpawnsContainer.SetActive(false);
        InimigosEliminadosRondaAtual = 0;

        QuantidadeInimigosEliminar *= 2;

        var inimigosRentantes = InimigosContainer.GetComponentsInChildren<InimigoBase_Script>();
        foreach (var inimigo in inimigosRentantes)
        {
            inimigo.AplicaMorte();
        }

        Temp_TimerNovaRonda = TimerNovaRonda;
        AtivaTimerNovaRonda = true;
    }
}
