using System.Collections;
using UnityEngine;

public class Aguardar_Comportamento : MonoBehaviour
{
    public bool passouTempo;

    public IEnumerator Aguardar(int SegundosReais)
    {
        passouTempo = false;
        yield return new WaitForSeconds(SegundosReais);
        passouTempo = true;
    }
}
