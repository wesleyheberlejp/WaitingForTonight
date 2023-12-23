using System.Collections.Generic;
using UnityEngine;

public class ArmaFogoBaseScript : MonoBehaviour
{
    public GameObject Projetil;
    public int QtdMunicao;
    public bool MunicaoInfinita;
    public float QtdDisparosDisponiveisPreReload;
    public float TempoReload;
    public List<Transform> pontosDisparo;

    private float Temp_TempoReload;
    private bool EstaEmReload = false;
    private float QtdDisparosPreReload = 0;

    private void Start()
    {
        Temp_TempoReload = TempoReload;
        if (Projetil == null) Debug.LogWarning("Nenhum Projétil foi definido");
    }

    private void FixedUpdate()
    {
        AplicaReload();
    }

    private void AplicaReload()
    {
        if (QtdDisparosPreReload < QtdDisparosDisponiveisPreReload) return;
        EstaEmReload = true;
        Temp_TempoReload -= Time.fixedDeltaTime;
        Debug.Log("On Reload");

        if (Temp_TempoReload > 0) return;

        EstaEmReload = false;
        Temp_TempoReload = TempoReload;
        QtdDisparosPreReload = 0;
        Debug.Log("Reload Finalizado");
    }

    public virtual void Dispara() 
    {
        if (EstaEmReload) return;
        if (Projetil == null) return;
        if (QtdMunicao <= 0 && !MunicaoInfinita)
        {
            AplicaNoAmmo();
            return;
        }

        QtdDisparosPreReload++;

        foreach (var pontoDisparo in pontosDisparo)
            Instantiate(Projetil, pontoDisparo.position, pontoDisparo.rotation);
    }

    private void AplicaNoAmmo()
    {
        return;
    }
}
