using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayers : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform enemy;

    public GameObject gameOverObject;
    public bool isGameOver = false;
    void Start()
    {
        
    }
    public void CheckCollision()
    {
        if (player1.position == player2.position || player1.position == enemy.position || player2.position == enemy.position)
        {
            gameOverObject.active = true;
            isGameOver = true;
            print("GAMEOVER");
        }
    }
}
