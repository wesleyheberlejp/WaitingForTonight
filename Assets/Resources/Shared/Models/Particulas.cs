using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Particulas
{
    private string _nome;
    public string Nome { get { return Material.name; } }
    public Sprite Material;
    public int Camada;
    public float Tamanho = 1;
}
