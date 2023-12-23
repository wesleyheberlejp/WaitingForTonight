using System.Collections.Generic;
using UnityEngine;

public class SpawnBase_Script : MonoBehaviour
{
    public List<GameObject> ItensSpawn;
    public float Timer = 10f;
    public GameObject ParenteAlocagem = null;
    public int QuantidadeSpawnar = 3;

    private float Temp_Timer = 0;


    private void Start()
    {
        Temp_Timer = Timer;
    }

    internal void SpawItem()
    {
        if (Temp_Timer > 0) return;
        if (QuantidadeSpawnar <= 0) return;

        if (ItensSpawn == null || ItensSpawn.Count == 0)
        {
            Debug.LogWarning("ItensSpaw não foi preenchido");
            ResetTimer();
            return;
        }

        var item = UtilitarioRandom.GetRandomOption(ItensSpawn);
        var Instancia = Instantiate(item, this.transform);

        if(ParenteAlocagem == null)
            Instancia.transform.parent = null;
        else
            Instancia.transform.parent = ParenteAlocagem.transform;

        ResetTimer();

        ItemSpawnado(Instancia);

        QuantidadeSpawnar--;
    }

    internal virtual void ItemSpawnado(GameObject item){}

    internal void ResetTimer()
    {
        Temp_Timer = Timer;

    }

    private void FixedUpdate()
    {
        TickTimer();
        SpawItem();
    }

    private void TickTimer()
    {
        if(Temp_Timer > 0) Temp_Timer -= Time.fixedDeltaTime;
        if (Temp_Timer < 0) Temp_Timer = 0;
    }
}
