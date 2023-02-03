using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MazeManager mazeManager;

    public List<Transform> playersTransforms;
    public List<Transform> enemiesTransforms;

    public GameObject gameOverObject;

    bool isGameOver = false;
    private void Start()
    {
        gameOverObject.active = false;
    }
    public void CheckCollision()
    {
        for (int i = 0; i < playersTransforms.Count - 1; i++)
        {
            for (int j = i + 1; j < playersTransforms.Count; j++)
            {
                Vector3 iPosition = playersTransforms[i].position;
                Vector3 jPosition = playersTransforms[j].position;
                if (iPosition == jPosition)
                {
                    GameOver();
                    return;
                }
            }
        }
        foreach (Transform playerTransform in playersTransforms)
        {
            foreach (Transform enemyTransform in enemiesTransforms)
            {
                if (playerTransform.position == enemyTransform.position)
                {
                    GameOver();
                    return;
                }
            }
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverObject.active = true;
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}
