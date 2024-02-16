using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboScript : InimigoBase_Script
{
    private void FixedUpdate()
    {
        VerificaDistanciaAlvo();
        BaseFixedUpdate();
    }

    private void VerificaDistanciaAlvo()
    {
        var distancia = GetDistanciaAlvo();

        if(distancia < 1)
            PerseguirAlvos = false;
        else
            PerseguirAlvos = true;
    }
}
