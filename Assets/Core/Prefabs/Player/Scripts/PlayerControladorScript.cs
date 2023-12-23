using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControladorScript : MonoBehaviour
{
    public static PlayerControladorScript Self;
    public PlayerImputsScript Inputs;
    public MovimentoControlador MovimentoControlador;
    public Animator Animator;
    public float ItensidadeMagnetudeMoviemnto = 1;

    [Header("Referencia Bones")]
    public GameObject MaoDireitaPontoLigacao;
    public GameObject MaoEsquerdaPontoLigacao;

    [Header("Equipamentos")]
    public GameObject ArmaEquipada;

    private float MagnetudeMovimento;

    private void Awake()
    {
        Self = this;
    }

    private void FixedUpdate()
    {
        AplicaMovimento();

        AplicaAnimacoes();
    }

    public void DisparoArmaEquipada()
    {
        if (ArmaEquipada == null) return;

        var arma = ArmaEquipada.GetComponent<ArmaFogoBaseScript>();

        if (arma == null) return;

        if(Animator != null) Animator.SetTrigger("Disparo");
        arma.Dispara();
    }

    private void AplicaMovimento()
    {
        MovimentoControlador.MoverseParaCamRelative(Inputs.Movimento, Camera.main);
    }

    private void AplicaAnimacoes()
    {
        if (Animator == null) return;

        if (Inputs.Movimento != Vector3.zero)
        {
            MagnetudeMovimento += ItensidadeMagnetudeMoviemnto * Time.fixedDeltaTime;
            if (MagnetudeMovimento > 1) MagnetudeMovimento = 1f;

        }
        else
        {
            MagnetudeMovimento -= ItensidadeMagnetudeMoviemnto * Time.fixedDeltaTime;
            if (MagnetudeMovimento < 0) MagnetudeMovimento = 0f;
        }

        Animator.SetFloat("Aceleracao", MagnetudeMovimento);
    }

}
