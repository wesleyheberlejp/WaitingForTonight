using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Versao
{

    public int Dia { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public int Build { get; set; }

    public Versao(int dia, int mes, int ano, int build)
    {
        this.Dia = dia;
        this.Mes = mes;
        this.Ano = ano;
        this.Build = build;
    }

}
