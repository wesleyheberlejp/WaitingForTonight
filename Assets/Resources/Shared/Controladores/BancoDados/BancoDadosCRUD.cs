using Assets.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

public class BancoDadosCRUD<T> where T : EntidadePersistenteBase, new()
{
    private BancoDadosConexao _banco;

    public BancoDadosCRUD(string nomeBanco)
    {
        _banco = new BancoDadosConexao(nomeBanco);
    }

    private string ObterNomeColunas()
    {
        string[] properties = typeof(T).GetProperties().Where(prop => prop.Name != "ID").Select(prop => prop.Name).ToArray();
        return string.Join(", ", properties);
    }

    private string ObterValoresColuna(T entidade)
    {
        string[] values = typeof(T).GetProperties().Where(prop => prop.Name != "ID").Select(prop => $"'{prop.GetValue(entidade)}'").ToArray();
        return string.Join(", ", values);
    }

    public List<T> Select(string campo, string valor)
    {
        var condicao = $"{campo} = '{valor}'";
        return Select_Where($"{condicao}");
    }
    public List<T> Select(string campo, int valor)
    {
        var condicao = $"{campo} = {valor}";
        return Select_Where($"{condicao}");
    }

    public List<T> Select(Dictionary<string, string> parametros)
    {
        StringBuilder sql = new StringBuilder();

        var condicoes = parametros.ToList();
        var length = parametros.Count();

        for (int i = 0; i < length; i++)
        {
            var numero = 0;
            int.TryParse(condicoes[i].Value, out numero);
            var ultimoRegistro = i == length - 1;

            string valor = numero != 0 ? numero.ToString() : $"'{condicoes[i].Value}'";

            sql.Append($"{condicoes[i].Key} = {valor}");

            if (!ultimoRegistro) sql.Append(" and ");
        }

        return Select_Where($"{sql}");
    }
    private string FormatarValorParaSQL(object value)
    {
        if (value == null)
        {
            return "NULL";
        }
        else if (value is string || value is DateTime)
        {
            return $"'{value}'";
        }
        else
        {
            return value.ToString();
        }
    }


    public void Update(T entidade)
    {
        string sqlQuery = $"UPDATE {typeof(T).Name} SET ";
        string sqlWhere = "";

        var properties = typeof(T).GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.Name != "ID")
            {
                sqlQuery += $"{property.Name} = {FormatarValorParaSQL(property.GetValue(entidade))}, ";
            }
            else
            {
                sqlWhere = $" WHERE ID = {property.GetValue(entidade)}";
            }

        }
        sqlQuery = sqlQuery.TrimEnd(',', ' ');
        sqlQuery += sqlWhere;
        _banco.Query.CommandText = sqlQuery;
        _banco.Query.ExecuteNonQuery();

    }

    public void Insert(T entidade)
    {
        string sqlQuery = $"INSERT INTO {typeof(T).Name} ({ObterNomeColunas()}) VALUES ({ObterValoresColuna(entidade)})";
        _banco.Query.CommandText = sqlQuery;
        _banco.Query.ExecuteNonQuery();
    }

    public List<T> Select()
    {
        List<T> entities = new List<T>();

        try
        {
            _banco.Query.CommandText = $"SELECT * FROM {typeof(T).Name}";

            using (IDataReader reader = _banco.Query.ExecuteReader())
            {
                while (reader.Read())
                {
                    T entity = new T();
                    Popular(reader, entity);
                    entities.Add(entity);
                }
            }
            return entities;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public List<T> Select_Where(string condicao)
    {
        try
        {
            List<T> entities = new List<T>();

            _banco.Query.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE {condicao}";

            using (IDataReader reader = _banco.Query.ExecuteReader())
            {
                while (reader.Read())
                {
                    T entity = new T();
                    Popular(reader, entity);
                    entities.Add(entity);
                }
            }
            return entities;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public List<T> Select(Func<T, bool> predicate)
    {
        List<T> entities = new List<T>();

        try
        {
            _banco.Query.CommandText = $"SELECT * FROM {typeof(T).Name}";

            using (IDataReader reader = _banco.Query.ExecuteReader())
            {
                while (reader.Read())
                {
                    T entity = new T();
                    Popular(reader, entity);
                    if (predicate(entity))
                    {
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public ResultadoPaginado<T> GetPaginado(string clausula, int pagina = 1)
    {
        ResultadoPaginado<T> paginacao = new ResultadoPaginado<T>();

        var offSet = pagina == 0 ? 0 : (pagina - 1) * 10;

        _banco.Query.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE {clausula} LIMIT 10 OFFSET {offSet}";

        using (IDataReader reader = _banco.Query.ExecuteReader())
        {
            while (reader.Read())
            {
                T entity = new T();
                Popular(reader, entity);
                paginacao.Itens.Add(entity);
            }
        }

        _banco.Query.CommandText = $"SELECT id FROM {typeof(T).Name} WHERE {clausula}";

        var totalItens = 0;
        using (IDataReader reader = _banco.Query.ExecuteReader())
        {
            while (reader.Read())
            {
                totalItens++;
            }
        }

        paginacao.TotalItens = totalItens;
        paginacao.NumeroPaginas = Convert.ToInt32(Math.Ceiling((double)totalItens / 10));

        return paginacao;
    }

    public void Remover()
    {
        _banco.Query.CommandText = $"DELETE FROM {typeof(T).Name}";
        _banco.Query.ExecuteNonQuery();
    }

    public void Remover(int id)
    {
        _banco.Query.CommandText = $"DELETE FROM {typeof(T).Name} WHERE ID = {id}";
        _banco.Query.ExecuteNonQuery();
    }

    private void Popular(IDataReader reader, T entidade)
    {
        Type type = typeof(T);
        do
        {
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    object value = reader[property.Name];
                    Type propertyType = property.PropertyType;

                    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }
                    if (value.GetType() != propertyType)
                    {
                        value = Convert.ChangeType(value, propertyType);
                    }
                    property.SetValue(entidade, value);
                }
            }

            type = type.BaseType;
        } while (type != null && type != typeof(object));

    }
    public void InsertOrUpdate(T entidade)
    {
        if (entidade.ID == 0)
        {
            Insert(entidade);
        }
        else
        {
            Update(entidade);
        }
    }
}
