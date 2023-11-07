using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TipoArquivos
{
    txt,
    uxml

}

public static class UtilitarioArquivos
{
    public static string ToString(this TipoArquivos arquivo)
    {
        string resultado;
        switch (arquivo)
        {
            case TipoArquivos.uxml:
                resultado = "uxml";
                break;
            default:
                resultado = "txt";
                break;
        }
        return resultado;
    }

    public static string ToExtension(this TipoArquivos arquivo)
    {
        var resultado = arquivo.ToString();
        return $".{resultado}";
    }
    public static string ToExtensionSearch(this TipoArquivos arquivo)
    {
        var resultado = arquivo.ToExtension();
        return $"*{resultado}";
    }
}
