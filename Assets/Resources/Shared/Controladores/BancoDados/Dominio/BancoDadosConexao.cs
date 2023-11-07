using Mono.Data.SqliteClient;
using System.Data;
using System.IO;
using UnityEngine;

public class BancoDadosConexao
{
    private IDbConnection _dbConnection;
    private IDbCommand _dbCommand;
    private string _nome;
    private string _diretorio = "";


    public BancoDadosConexao(string nomedb) 
    {
        _nome = nomedb;
    }
    public string Nome { get => _nome; }
    public string Diretorio
    {

        get
        {
            if (_diretorio == string.Empty)
            {
                _diretorio = Path.Combine(DiretorioManager.Diretorio, Nome);
            }
            return _diretorio;  
        }
    }
     
    public IDbConnection Conexao
    {
        get
        {
            if (_dbConnection == null)
            {
                _dbConnection = ObterConexao();
            }
            return _dbConnection;
        }
    }

    public IDbCommand Query
    {
        get
        {
            if (_dbCommand == null)
            {
                _dbCommand = Conexao.CreateCommand();
            }
            if (_dbCommand.Connection.State <= ConnectionState.Closed)
            {
                _dbCommand.Connection.Open();
            }
            return _dbCommand;
        }
    }

    public string ObterStringConexao()
    {
        var _path = Path.Combine(Diretorio);
        return $"URI=file:{_path}";
    } 

    private IDbConnection ObterConexao()
    {
        var _stringConexao = ObterStringConexao();

        return new SqliteConnection(_stringConexao);
         
    }

}
