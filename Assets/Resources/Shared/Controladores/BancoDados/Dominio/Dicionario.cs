using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Dicionario : EntidadePersistenteBase
{
    public string PortuguesBr { get; set; }
    public string PortuguesPt { get; set; }
    public string InglesUs { get; set; }
    public string EspanholEs { get; set; }
    public string FrancesFr { get; set; }
    public string RussoRu { get; set; }
    public string AlemaoDe { get; set; }
    public string JaponesJa { get; set; }

    public string Traducao(IdiomasEnum idioma)
    {
        string valorTraduzido;
        switch (idioma)
        {
            case IdiomasEnum.PortuguesPt:
                valorTraduzido = PortuguesBr;
                break;
            case IdiomasEnum.InglesUs:
                valorTraduzido = InglesUs;
                break;
            case IdiomasEnum.EspanholEs:
                valorTraduzido = EspanholEs;
                break;
            case IdiomasEnum.FrancesFr:
                valorTraduzido = FrancesFr;
                break;
            case IdiomasEnum.RussoRu:
                valorTraduzido = RussoRu;
                break;
            case IdiomasEnum.AlemaoDe:
                valorTraduzido = AlemaoDe;
                break;
            case IdiomasEnum.JaponesJa:
                valorTraduzido = JaponesJa;
                break;
            default:
                valorTraduzido = PortuguesBr;
                break;
        }
        return valorTraduzido;
    }

    public bool Contem(string palavra)
    {
        Type tipo = this.GetType();
        var encontrou = false;
        PropertyInfo[] propriedades = tipo.GetProperties();
        foreach (var propriedade in propriedades)
        {
            if (propriedade.PropertyType == typeof(string))
            {
                var valor = (string)propriedade.GetValue(this);

                if (valor.ToUpper() == palavra.ToUpper())
                {
                    encontrou = true;
                    break;
                }
            }

        }
        return encontrou;
    }
}
