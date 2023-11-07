using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Shared.Servicos
{
    public class JsonLoader_Servico
    {
        public static string Load(string caminhoCompletoJson)
        {
            if (File.Exists(caminhoCompletoJson))
                return File.ReadAllText(caminhoCompletoJson);

            return null;
        }
    }
}
