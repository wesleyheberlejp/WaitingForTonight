using Assets.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BaseController<T> : IBaseController<T> where T : EntidadePersistenteBase, new()
{
    private BancoDadosCRUD<T> _bancoDadosCrud;

    public BaseController(string nomeBanco)
    {
        _bancoDadosCrud = new BancoDadosCRUD<T>(nomeBanco);
    }

    public List<T> Obter()
    {
        return _bancoDadosCrud.Select();
    }
    public List<T> Obter(Func<T, bool> condicao)
    {
        return _bancoDadosCrud.Select(condicao);
    }

    public async Task Inserir(T entidade)
    {
        _bancoDadosCrud.Insert(entidade);
        await Task.CompletedTask;
    }

    public async Task Atualizar(T entidade)
    {
        _bancoDadosCrud.Update(entidade);
        await Task.CompletedTask;
    }

    public async Task RemoverTodos()
    {
        _bancoDadosCrud.Remover();
        await Task.CompletedTask;
    }

    public async Task Remover(int ID)
    {
        _bancoDadosCrud.Remover(ID);
        await Task.CompletedTask;
    }

    public ResultadoPaginado<T> GetPaginado(string clausula, int pagina = 1)
    {
        return _bancoDadosCrud.GetPaginado(clausula, pagina);
    }

    public async Task InserirOuAtualizar(T entidade)
    {
        _bancoDadosCrud.InsertOrUpdate(entidade);
        await Task.CompletedTask;
    }

    public List<T> Obter(string comando)
    {
        return _bancoDadosCrud.Select_Where(comando);
    }

    public List<T> Obter(string campo, string valor)
    {
        return _bancoDadosCrud.Select(campo, valor);
    }

    public List<T> Obter(string campo, int valor)
    {
        return _bancoDadosCrud.Select(campo, valor);
    }
}
