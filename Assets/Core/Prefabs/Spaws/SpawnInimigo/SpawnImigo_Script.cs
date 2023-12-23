using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnImigo_Script : SpawnBase_Script
{
    public List<GameObject> ImigosAlvos;

    internal override void ItemSpawnado(GameObject item)
    {
        item.GetComponent<InimigoBase_Script>().Alvos = ImigosAlvos;
    }
}
