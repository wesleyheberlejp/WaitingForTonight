using Assets.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBaseController<T> where T: EntidadePersistenteBase
{
    Task Atualizar(T entidade);
    ResultadoPaginado<T> GetPaginado(string clausula, int pagina = 1);
    Task Inserir(T entidade);
    Task InserirOuAtualizar(T entidade);
    List<T> Obter();
    List<T> Obter(Func<T, bool> condicao);
    List<T> Obter(string comando);
    List<T> Obter(string campo, int valor);
    List<T> Obter(string campo, string valor);
    Task Remover(int ID);
    Task RemoverTodos();

}
