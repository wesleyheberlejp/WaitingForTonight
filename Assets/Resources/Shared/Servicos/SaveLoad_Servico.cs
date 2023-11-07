using Assets.Shared.Models.SaveFile;
using Newtonsoft.Json;
using System;
using System.IO;

public static class SaveLoad_Servico
{
    public static string CaminhoSaves = "";
    public static void Save(Base_SaveData saveData)
    {
        if(saveData == null)
            return;

        var saveFile = new Base_SaveFile(saveData.Nome, saveData.ToJson());
      
        if(!Directory.Exists(CaminhoSaves))
            Directory.CreateDirectory(CaminhoSaves);

        var caminhoCompleto = $"{Path.Combine(CaminhoSaves, saveFile.Nome)}.save";

        saveFile.DataModificacao =  DateTime.Now;
        var save = JsonConvert.SerializeObject(saveFile);

        File.WriteAllText(caminhoCompleto, save);
    }

    public static string Load(string nomeArquivo)
    {
        var caminhoCompleto = $"{Path.Combine(CaminhoSaves, nomeArquivo)}.save";

        if (File.Exists(caminhoCompleto)) 
            return File.ReadAllText(caminhoCompleto);

        return null;
    }
}
