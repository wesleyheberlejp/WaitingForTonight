using UnityEngine;

public class Tiro_Comportamento : MonoBehaviour
{
    public TipoDirecaoMovimentoBala_Enum Direcao;
    [Tooltip("Tambem pode ser atibuido pelo metodo SetVelocidade")]
    public float Velocidade = 5f;

    private void FixedUpdate()
    {
        switch (Direcao)
        {
            case TipoDirecaoMovimentoBala_Enum.Esquerda:
                this.transform.Translate(new Vector3((Time.fixedDeltaTime * Velocidade) * -1, 0f, 0f));
                break;
            case TipoDirecaoMovimentoBala_Enum.Direita:
                this.transform.Translate(new Vector3(Time.fixedDeltaTime * Velocidade, 0f, 0f));
                break;
            case TipoDirecaoMovimentoBala_Enum.Cima:
                this.transform.Translate(new Vector3(0f, Time.fixedDeltaTime * Velocidade,0f ));
                break;
            case TipoDirecaoMovimentoBala_Enum.Frente:
                this.transform.Translate(new Vector3(0f, 0f, Time.fixedDeltaTime * Velocidade));
                break;
        }
    }

    public void SetVelocidade(float valor)
    {
        Velocidade = valor;
    }
}
