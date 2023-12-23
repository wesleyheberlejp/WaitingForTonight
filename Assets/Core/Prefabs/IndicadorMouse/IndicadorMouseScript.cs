using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorMouseScript : MonoBehaviour
{
    public Camera cam;
    public LayerMask mask;
    private void Update()
    {
        this.transform.position = UtilitariosGerais.ObterPosicaoMouseMundo(cam, mask.value);
    }
}
