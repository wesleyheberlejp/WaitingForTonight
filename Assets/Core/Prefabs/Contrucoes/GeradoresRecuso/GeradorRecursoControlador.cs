using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DtoRetornoRecursoGerado
{
    public string Recurso;
    public int Quantidade { get; set; }
}

public class GeradorRecursoControlador : MonoBehaviour
{
    public bool Ativado = true;
    public float IntervaloGeracao = 5f;
    public float TempIntervaloGeracao = 0;

    internal int QuantidadeGerada = 0;

    private void Awake()
    {
        TempIntervaloGeracao = IntervaloGeracao;
    }

    private void FixedUpdate()
    {
        if (!Ativado) return;

        if (TempIntervaloGeracao > 0) TempIntervaloGeracao -= Time.fixedDeltaTime;

        if(TempIntervaloGeracao < 0)
        {
            //gera recurso
            GerarRecurso();
            ResetGerador();
        }
    }

    private void GerarRecurso()
    {
        QuantidadeGerada++;
    }

    private void ResetGerador()
    {
        TempIntervaloGeracao = IntervaloGeracao;
    }

    private DtoRetornoRecursoGerado ColetarRecursos()
    {
        var retorno = new DtoRetornoRecursoGerado()
        {
            Recurso = "teste",
            Quantidade = QuantidadeGerada
        };

        QuantidadeGerada = 0;

        return retorno;
    }

}
