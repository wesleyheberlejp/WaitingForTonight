using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoControlador : MonoBehaviour
{
    public float VelocidadeMaxima = 3f;
    public float Aceleracao = 3f;
    public float IntensidadeGravidade = 0.3f;
    public bool ReduzirVelocidadeMovimentoTras = false;
    public bool UsarGravidade = false;
    public bool MovimentoVertical = false;

    public float ForcaPulo = 3f;
    public CharacterController CharacterController;
    private Camera Cam;
    internal Vector3 DirecaoMovimento;

    //Gravidade
    private float ForcaGravidade = 9.81f;
    private float VelocidadeGravidade;

    //Velocidade
    private float VelocidadeMovimento = 1f;

    public void MoverseParaCamRelative(Vector3 movimento, Camera cam, bool Pular = false)
    {
        Cam = cam;
        DirecaoMovimento = GetDirecaoRelativaACamera(movimento.x, movimento.z);
        //DirecaoMovimento.x = temDirecaoMovimento.x;
        //DirecaoMovimento.z = temDirecaoMovimento.z;

        if (MovimentoVertical)
            DirecaoMovimento.y = movimento.y;

        if (Pular)
            AplicaPulo();

        if (UsarGravidade)
            AplicaGravidade();


        if (movimento != Vector3.zero)
            VelocidadeMovimento += Aceleracao * Time.fixedDeltaTime;
        else
            VelocidadeMovimento = 1;

        if (VelocidadeMovimento > VelocidadeMaxima) VelocidadeMovimento = VelocidadeMaxima;

        if (VelocidadeMovimento < 0) VelocidadeMovimento = 0;

        if (!CharacterController.isGrounded && UsarGravidade) VelocidadeMovimento = ForcaGravidade;

        if (movimento.z < 0 && ReduzirVelocidadeMovimentoTras)
        {
            VelocidadeMovimento = VelocidadeMaxima / 2;
        }

        CharacterController.Move(DirecaoMovimento * VelocidadeMovimento * Time.fixedDeltaTime);
    }

    public void MoversePara(Vector3 direcaoMovimento)
    {
        DirecaoMovimento = direcaoMovimento;

        VelocidadeMovimento += Aceleracao * Time.fixedDeltaTime;

        if (VelocidadeMovimento > VelocidadeMaxima) VelocidadeMovimento = VelocidadeMaxima;

        if (UsarGravidade)
            AplicaGravidade();

        CharacterController.Move(DirecaoMovimento * VelocidadeMovimento * Time.fixedDeltaTime);
    }

    private void AplicaPulo()
    {
        if (CharacterController.isGrounded)
        {
            VelocidadeGravidade = -ForcaPulo;
        }
    }

    public void AplicaGravidade()
    {

        if (!CharacterController.isGrounded)
        {
            VelocidadeGravidade += ForcaGravidade * IntensidadeGravidade * Time.fixedDeltaTime;
        }

        if (CharacterController.isGrounded && VelocidadeGravidade > 1)
        {
            VelocidadeGravidade = 1;
        }

        DirecaoMovimento.y -= VelocidadeGravidade;
    }

    private Vector3 GetDirecaoRelativaACamera(float horizontal, float vertical)
    {
        if (Cam != null)
        {
            // Obtém a direção para a frente da câmera
            Vector3 cameraForward = Cam.transform.forward;
            cameraForward.y = 0; // Mantém a direção horizontal

            // Obtém a direção para a direita da câmera
            Vector3 cameraRight = Cam.transform.right;

            // Calcula a direção de movimento relativa à câmera
            Vector3 direcaoRelativaACamera = (cameraForward.normalized * vertical) + (cameraRight.normalized * horizontal);

            return direcaoRelativaACamera.normalized; // Normaliza a direção
        }
        else
        {
            return Vector3.zero;
        }
    }
}
