using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilBase_Script : MonoBehaviour
{
    public int Dano = 1;
    public float LifeTime = 3f;

    private void FixedUpdate()
    {
        LifeTime -= Time.fixedDeltaTime;

        if(LifeTime < 0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "INIMIGO":
                var InimigoScript = other.gameObject.GetComponent<InimigoBase_Script>();
                if (InimigoScript != null)
                    InimigoScript.RecebeDano(Dano);
                break;
        }

        switch (other.gameObject.tag)
        {
            case "PROJETIL":
                break;
            case "PLAYER":
                break;
            default:
                Destroy(gameObject);
                break;
        }
        
    }
}
