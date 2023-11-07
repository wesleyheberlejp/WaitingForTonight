using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandirCentro_Script_Animation : MonoBehaviour
{
    public Vector3 TamanhoDestino = Vector3.one;
    public float Velocidade = 3f;
    private void Awake()
    {
        this.transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        this.transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if(this.transform.localScale != TamanhoDestino)
        {
            var lerp = Vector3.Lerp(this.transform.localScale, TamanhoDestino, Velocidade * Time.fixedDeltaTime);
            this.transform.localScale = lerp;
        }
    }
}
