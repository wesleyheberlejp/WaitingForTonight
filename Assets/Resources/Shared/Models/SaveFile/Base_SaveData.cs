using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Shared.Models.SaveFile
{
    public class Base_SaveData
    {
        public Base_SaveData(string nome)
        {
            Nome = nome;
        }

        public string Nome ;
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
