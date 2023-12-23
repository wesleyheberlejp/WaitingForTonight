using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UtilitariosGerais 
{
    private static  Vector3 ultimaPosicao = Vector3.zero;

    public static bool MouseIsOnUi = false;

    public static Vector3 ObterPosicaoMouseMundo(Camera _camera, int layerId) 
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray raio = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(raio, out hit, 100, layerId))
        {
            if (!hit.collider.isTrigger)
                ultimaPosicao = hit.point;
        }

        return ultimaPosicao;
    }

    public static bool EstaColidindo(BoxCollider box)
    {
        Vector3 center = box.transform.TransformPoint(box.center);

        var overlapObjs = Physics.OverlapBox(center, box.size / 2, box.transform.rotation).ToList();
        overlapObjs.Remove(box);
        var isOverlaping = overlapObjs.Where(p => p != box && p.isTrigger);

        return overlapObjs.Any();
    }

    public static void DebugBoxCollider(BoxCollider box, Transform PaiColliderTransform)
    {
        // Desenha o CheckBox para visualização na cena
        if (box != null)
        {
            Gizmos.color = Color.cyan;
            Vector3 center = box.transform.TransformPoint(box.center);
            Gizmos.DrawWireCube(center, box.size);
        }
    }
}
