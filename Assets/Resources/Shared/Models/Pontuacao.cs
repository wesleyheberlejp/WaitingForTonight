using System;
using UnityEngine;

[Serializable]
public class Pontuacao
{
    public string Nome { get; }
    public int Pontucacao { get; }


    public Pontuacao(string nome, int pontuacao)
    {
        this.Nome = nome;
        this.Pontucacao = pontuacao;
    }
}
