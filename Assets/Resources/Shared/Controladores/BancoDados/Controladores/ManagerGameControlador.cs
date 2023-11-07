using UnityEngine;

public class ManagerGameControlador : MonoBehaviour
{
    public ManagerGame Repositorio;

    private void Awake()
    {
        Repositorio = new ManagerGame();
    }
}
