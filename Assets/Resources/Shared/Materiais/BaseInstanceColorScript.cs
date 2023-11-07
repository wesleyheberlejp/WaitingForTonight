using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseInstanceColorScript : MonoBehaviour
{
    public Color[] Cores;
    internal Material[] ObjMateriais;
    void Awake()
    {
        try
        {
            ObjMateriais = GetComponent<MeshRenderer>().materials;

            for (int i = 0; i < Cores.Length; i++)
            {
                ObjMateriais[i].color = Cores[i];
            }
        }
        catch (System.Exception)
        {
            Debug.Log($"Seu Objeto tem mais cores {Cores.Count()} do que texturas mapeadas {ObjMateriais.Count()}");
        }
    }
}
