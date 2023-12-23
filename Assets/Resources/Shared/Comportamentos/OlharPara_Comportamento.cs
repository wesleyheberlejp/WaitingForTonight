using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlharPara_Comportamento : MonoBehaviour
{
    public Camera Camera;
    public GameObject Alvo;
    public LayerMask Layer;
    public bool IncluirVertical = false;
    public bool OlharMouse = false;

    private void Update()
    {
        OlharParaAlvo();
        OlharParaMouse();
    }

    public void OlharParaMouse()
    {
        if (!OlharMouse) return;

        var mousePosicao = UtilitariosGerais.ObterPosicaoMouseMundo(Camera, Layer.value);

        Vector3 direcaoOlhar = mousePosicao - this.transform.position;
        if (!IncluirVertical)
            direcaoOlhar.y = 0;

        this.transform.LookAt(this.transform.position + direcaoOlhar);

    }

    private void OlharParaAlvo()
    {
        if (OlharMouse) return;
        if (Alvo == null) return;

        var direcaoOlhar = Alvo.transform.position - this.transform.position;

        this.transform.LookAt(this.transform.position + direcaoOlhar);
    }
}

