
using UnityEngine;

public class GameObject_Servico
{
    public static GameObject ObterGameObjectFilhoPorNomeDeTag(Transform pai, string nomeTag)
    {
        foreach (Transform filho in pai)
        {
            if (filho.CompareTag(nomeTag))
            {
                return filho.gameObject;
            }


            GameObject filhoComTagDefinida = ObterGameObjectFilhoPorNomeDeTag(filho, nomeTag);
            if (filhoComTagDefinida != null)
            {
                return filhoComTagDefinida;
            }
        }
        return null;
    }
}
