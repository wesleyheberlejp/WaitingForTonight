using System.IO;
using UnityEngine;

public static class DiretorioManager
{
    public static string Diretorio
    {
        get
        {
            string _diretorio = Path.GetDirectoryName(Application.dataPath);

            switch (Plataforma)
            {
                case TPlataformas.Windows:
                    _diretorio = Path.GetDirectoryName(Application.dataPath);
                    break;

            }

            return _diretorio;
        }
    }

   
    public static TPlataformas Plataforma
    {
        get
        {
            return new PlataformasControlador().ObterPlataforma();
        }
    }

    public static string DiretorioCompleto
    {
        get { return Path.Combine(Diretorio); }
    }


}
