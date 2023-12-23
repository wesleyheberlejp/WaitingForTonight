using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InimigoBase_Script : MonoBehaviour
{
    [Header("Movimento")]
    public MovimentoControlador MovimentoControlador;

    [Header("------------------------------>")]
    [Header("Status")]
    public int Vida = 3;
    public float Velocidade_Ataque;

    [Header("------------------------------>")]
    [Header("Referencias")]
    public ParticleSystem ParticleSystem;
    public Animator Animator;
    public GameObject Armature;

    [Header("Variaveis")]
    public float TimerPosMorte = 3f;

    internal int Temp_Vida;
    internal float Temp_Velocidade;
    internal float Temp_Velocidade_Ataque;

    internal CharacterController CharacterController;

    internal Rigidbody[] RagDollRBs;
    private bool EstaVivo;

    [Header("---------------------------------------------------->")]
    public List<GameObject> Alvos;

    private void Awake()
    {
        RagDollRBs = Armature.GetComponentsInChildren<Rigidbody>();
        SetRagDoll(false);
        EstaVivo = true;
    }

    private void Start()
    {
        try
        {
            CharacterController = GetComponent<CharacterController>();
        }
        catch (System.Exception)
        {
            Debug.LogError("Não foi configuração charactereController");
        }

        if (Alvos != null)
        {
            GetComponentInChildren<OlharPara_Comportamento>().Alvo = Alvos.FirstOrDefault();
        }
    }

    private void FixedUpdate()
    {
        AplicaDestroiGradual();
        AplicaInteligencia();
    }

    private void AplicaInteligencia()
    {
        if (!EstaVivo) return;
        PersegueAlvoByPrioridade();
    }

    private void AplicaDestroiGradual()
    {
        var delta = Time.fixedDeltaTime;

        if (EstaVivo) return;
        TimerPosMorte -= delta;
        var mainParticle = ParticleSystem.main;
        mainParticle.loop = true;
        ParticleSystem.Play();
        if (TimerPosMorte > 0) return;

        var deltaEscala = delta / 4;

        var escalaAtual = transform.localScale;
        escalaAtual.x -= deltaEscala;
        escalaAtual.y -= deltaEscala;
        escalaAtual.z -= deltaEscala;
        var escalaModificada = escalaAtual;
        transform.localScale = escalaModificada;

        if (transform.localScale.x < 0.1) Destroy(this.gameObject);
    }

    private void PersegueAlvoByPrioridade()
    {

        //Após a Demo deve ser feita uma inteligencia de movimento

        if (Alvos == null || Alvos.Count == 0)
        {
            Debug.LogWarning("Alvos não foram definidos");
        }

        var alvoPrincipal = Alvos.Where(p => p != null && p.activeSelf).FirstOrDefault();

        if (alvoPrincipal != null)
        {
            Vector3 direction = alvoPrincipal.transform.position - transform.position;
            direction.Normalize();

            MovimentoControlador.MoversePara(direction);
        }
    }

    public void RecebeDano(int valorDano)
    {
        if (Vida > 0)
        {
            Vida -= valorDano;
            ParticleSystem.Play();
        }

        if (Vida <= 0)
        {
            EmissorEvento_Service.EmiteMenssagem(TipoNotificacao_Enum.InimigoEliminado);
            AplicaMorte();
        }
    }

    public void AplicaMorte()
    {
        GetComponentInChildren<OlharPara_Comportamento>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        Animator.enabled = false;
        SetRagDoll(true);
        EstaVivo = false;
    }

    public void SetRagDoll(bool ativar)
    {
        if (RagDollRBs == null) return;
        if (RagDollRBs.Count() == 0) return;

        foreach (var item in RagDollRBs)
        {
            if (ativar)
            {

                item.isKinematic = false;
            }
            else
            {
                item.isKinematic = true;
            }
        }
    }
}
