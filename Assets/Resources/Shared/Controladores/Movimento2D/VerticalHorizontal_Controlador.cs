using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VerticalHorizontal_Controlador : MonoBehaviour
{
    public GameObject TargetHorizontal;
    public GameObject TargetVertical;
    public float VelocidadeMovimento;

    internal Vector2 Movimento;
    internal Vector3 PlayerPosicaoDestino;
    internal Rigidbody2D Rb;

    private void Awake()
    {
        this.Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
  
            if (Movimento.x != 0) AtualizaMovimentoHorizontal();
            if (Movimento.y != 0) AtualizaMovimentoVertical();


            PlayerPosicaoDestino = new Vector3
            {
                x = TargetHorizontal.transform.position.x,
                y = TargetVertical.transform.position.y,
                z = 0f
            };

        MovePlayer();
    }

    private void MovePlayer()
    {
        if (this.transform.position != PlayerPosicaoDestino)
        {
            var smooth = Vector3.Lerp(this.transform.position, PlayerPosicaoDestino, VelocidadeMovimento * Time.fixedDeltaTime);
            this.Rb.MovePosition(smooth);
        }
    }

    private void AtualizaMovimentoHorizontal()
    {
        var tempPosicao = TargetHorizontal.transform.position.x + Movimento.x;
        var x = Mathf.Lerp(TargetHorizontal.transform.position.x, tempPosicao, 0.3f);
        var y = TargetHorizontal.transform.position.y;
        TargetHorizontal.transform.position = new Vector3(x, y, 0f);
    }

    private void AtualizaMovimentoVertical()
    {
        var tempPosicao = TargetVertical.transform.position.y + Movimento.y;
        var y = Mathf.Lerp(TargetVertical.transform.position.y, tempPosicao, 0.3f);
        var x = TargetVertical.transform.position.x;
        TargetVertical.transform.position = new Vector3(x, y, 0f);
    }

    void OnMove(InputValue value)
    {
        Movimento = value.Get<Vector2>();
    }
}
