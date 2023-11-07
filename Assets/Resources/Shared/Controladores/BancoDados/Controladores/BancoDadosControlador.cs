using System;
using System.IO;
using UnityEngine;

public class BancoDadosControlador: MonoBehaviour
{
    private BancoDadosConexao _banco;
    [SerializeField]
    private string NomeDataBase;

    public BancoDadosConexao Conexao { get => _banco; }

    private void Awake()
    {
        _banco = new BancoDadosConexao(NomeDataBase);
        CriarBaseDados();
    }
    private void CriarBaseDados()
    {
        if (!File.Exists(_banco.Diretorio))
        {
            _banco.Conexao.Open();
            _banco.Conexao.Close();
        }
    }
}
