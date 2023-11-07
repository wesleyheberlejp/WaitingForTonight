using UnityEngine;

public class ManagerGame : ManagerBase
{
    [HideInInspector]
    //Adicionar models
    private void DefinirControllersGame()
    {
        //Instanciar models
    }

    public ManagerGame() : base("game.db")
    {
        DefinirControllersGame();
    }
}
