
using UnityEngine;

public static class Plataforma_Servico
{
    private static TPlataformas _tipoPlataforma;


    public static TPlataformas ObterPlataforma()
    {
        switch (Application.platform)
        {

            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.OSXPlayer:
                _tipoPlataforma = TPlataformas.Mac;
                break;

            case RuntimePlatform.Android:
                _tipoPlataforma = TPlataformas.Android;
                break;

            case RuntimePlatform.IPhonePlayer:
                _tipoPlataforma = TPlataformas.IOS;
                break;
            case RuntimePlatform.GameCoreXboxSeries:
            case RuntimePlatform.GameCoreXboxOne:
                _tipoPlataforma = TPlataformas.XBOX;
                break;
            case RuntimePlatform.PS4:
            case RuntimePlatform.PS5:
                _tipoPlataforma = TPlataformas.PlayStation;
                break;
            case RuntimePlatform.Switch:
                _tipoPlataforma = TPlataformas.NintedoSwitch;
                break;


        }

        return _tipoPlataforma;

    }

}
