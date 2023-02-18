using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeButtom : MonoBehaviour
{
    public void SetSinglePlayer()
    {
        MenuManager.shared.SetGameMode(GameMode.SinglePlayer);
    }
    public void SetMultiPlayer()
    {
        MenuManager.shared.SetGameMode(GameMode.MultiPlayer);
    }
}
