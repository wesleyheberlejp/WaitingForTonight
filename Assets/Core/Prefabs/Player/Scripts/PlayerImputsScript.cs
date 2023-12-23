using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerImputsScript : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Movimento;

    public void SetMovimento(InputAction.CallbackContext context)
    {
        var v2 = context.ReadValue<Vector2>();
        Movimento = new Vector3(v2.x, 0f, v2.y);
    }

    public void SetDisparo(InputAction.CallbackContext context)
    {
        if (context.performed)
            PlayerControladorScript.Self.DisparoArmaEquipada();
    }
}
