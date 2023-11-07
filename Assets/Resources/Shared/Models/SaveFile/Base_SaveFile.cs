using System;

public class Base_SaveFile
{
    public Base_SaveFile(string nomeSave, string data)
    {
        Nome = nomeSave;
        DataModificacao = DateTime.Now;
        Versao = "1.0";
        Data = data;
    }

    public string Nome ;
    public string Versao ;
    public DateTime DataModificacao ;
    public string Data ;

}
