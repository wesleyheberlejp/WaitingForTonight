using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguracoesGameController : ConfiguracaoController
{
    public ConfiguracoesGameController(string nomeBanco) : base(nomeBanco)
    {

    }
    public bool MostrarIndicadorBloco
    {
        get { return ObterMostrarIndicadorBloco(); }
        set { DefinirMostrarIndicadorBloco(value); }
    }
    public string ResolucaoTela
    {
        get { return ObterResolucaoTela(); }
        set { DefinirMostrarResolucaoTela(value); }
    }
    public float SensibilidadeMouseEixoX
    {
        get { return ObterSensibilidadeMouseEixoX(); }
        set { DefinirSensibilidadeMouseEixoX(value); }
    }
    public float SensibilidadeMouseEixoY
    {
        get { return ObterSensibilidadeMouseEixoY(); }
        set { DefinirSensibilidadeMouseEixoY(value); }
    }
    public string Idioma
    {
        get { return ObterIdiomaJogo(); }
        set { DefinirIdiomaJogo(value); }
    }

    public IdiomasEnum TipoIdioma { get => Idioma.Tipo(); }
    private void DefinirMostrarIndicadorBloco(bool valor)
    {
        base.Inserir("GERAL", "MOSTRARINDICADORBLOCO", valor);
    }
    private bool ObterMostrarIndicadorBloco()
    {
        return base.Obter("GERAL", "MOSTRARINDICADORBLOCO", true);
    }
    private void DefinirMostrarResolucaoTela(string valor)
    {
        base.Inserir("TELA", "RESOLUCAO", valor);
    }
    private string ObterResolucaoTela()
    {
        return base.Obter("TELA", "RESOLUCAO", "1920, 1080");
    }
    private void DefinirSensibilidadeMouseEixoX(float valor)
    {
        base.Inserir("MOUSE", "SENSIBILIDADEX", valor.ToString());
    }
    private float ObterSensibilidadeMouseEixoX()
    {
        float resultado;
        float.TryParse(base.Obter("MOUSE", "SENSIBILIDADEX", "2000"), out resultado);
        return resultado;
    }

    private void DefinirSensibilidadeMouseEixoY(float valor)
    {
        base.Inserir("MOUSE", "SENSIBILIDADEY", valor.ToString());
    }
    private float ObterSensibilidadeMouseEixoY()
    {
        float resultado;
        float.TryParse(base.Obter("MOUSE", "SENSIBILIDADEY", "10"), out resultado);
        return resultado;
    }
    private void DefinirIdiomaJogo(string valor)
    {
        base.Inserir("GERAL", "IDIOMA", valor);
    }
    private string ObterIdiomaJogo()
    {
        return base.Obter("GERAL", "IDIOMA", IdiomasEnum.InglesUs.Sigla());
    }


}
