using System.Collections.Generic;

public class DicionarioController : BaseController<Dicionario>
{
    private List<Dicionario> _listaTraducoes;
    public DicionarioController(string nomeBanco) : base(nomeBanco)
    {
    }

    public List<Dicionario> ObterTraducoes()
    {
        if (_listaTraducoes == null)
        {
            _listaTraducoes = base.Obter();
        }

        return _listaTraducoes;
    }

}
