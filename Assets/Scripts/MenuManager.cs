using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {
    SinglePlayer,
    MultiPlayer,
}

public class MenuManager : MonoBehaviour
{
    public static MenuManager shared;
    public GameMode gameMode;

    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetGameMode(GameMode gameMode)
    {
        this.gameMode = gameMode;
    }
}
