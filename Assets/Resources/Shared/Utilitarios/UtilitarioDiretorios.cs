using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public static class UtilitarioDiretorios
{
    public static string DiretorioBase() { return Application.dataPath; }
    private static string FormatarDiretorioPorSistemaOperacional(string diretorio)
    {
        const string map = "@separador@";
        diretorio = diretorio.Replace("\\", map);
        diretorio = diretorio.Replace("//", map);
        diretorio = diretorio.Replace("/", map);
        return diretorio.Replace(map, Path.DirectorySeparatorChar.ToString());
      
    }
    public static string ConcatenarDiretorioComDiretorioBase(string dir)
    {
        return FormatarDiretorioPorSistemaOperacional($"{DiretorioBase()}/{dir}");
    }
    public static string ConcatenarDiretorioComArquivo(string dir, string arquivo)
    {
        var diretorioCompleto = ConcatenarDiretorioComDiretorioBase(dir);
        return FormatarDiretorioPorSistemaOperacional($"{diretorioCompleto}/{arquivo}");

    }
    private static List<string> ObterArquivosDoDiretorio(string diretorio, TipoArquivos tipoArquivo)
    {
        var listaArquivos = new List<string>();
        var dir = ConcatenarDiretorioComDiretorioBase(diretorio);

        if (Directory.Exists(dir))
        {
            var files = Directory.GetFiles(dir, tipoArquivo.ToExtensionSearch(), SearchOption.AllDirectories);
            foreach (string file in files)
            {
                listaArquivos.Add(FormatarDiretorioPorSistemaOperacional(file));
            }
        }
        else
        {
            Debug.LogWarning("A pasta especificada não existe: " + diretorio);
        }


        return listaArquivos;
    }

    public static Object[] ObterArquivos(this string diretorio)
    {
        return Resources.LoadAll(diretorio);
    }
}
