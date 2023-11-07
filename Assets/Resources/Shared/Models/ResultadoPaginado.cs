using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Shared.Models
{
    public class ResultadoPaginado<T>
    {
        public ResultadoPaginado()
        {
            Pagina = 1;
            ItensPorPagina = 10;
            Itens = new List<T>();
        }

        public int Pagina;
        public int TotalItens;
        public int NumeroPaginas;
        public int ItensPorPagina;
        public List<T> Itens;

    }
}
