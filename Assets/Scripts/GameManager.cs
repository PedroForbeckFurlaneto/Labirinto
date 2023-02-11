using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MazeManager mazeManager;

    private List<Transform> playersTransforms = new List<Transform>();
    private List<Transform> enemiesTransforms = new List<Transform>();

    public GameObject gameOverObject;

    public GameObject player1Model;
    public GameObject player2Model;
    public GameObject enemyModel;
    public Transform player1Position;
    public Transform player2Position;
    public Transform enemyPosition;

    public int gamemode = 0;

    public bool stopGame = false;

    bool isGameOver = false;
    private void Start()
    {
        gameOverObject.active = false;
        CharacterInstantiate(player1Model, player1Position.position, playersTransforms);
        if (gamemode == 0)
        {
            CharacterInstantiate(player2Model, player2Position.position, playersTransforms);
        }
        else
        {
            CharacterInstantiate(enemyModel, enemyPosition.position, enemiesTransforms);
        }
    }

    private void CharacterInstantiate(GameObject model, Vector3 position, List<Transform> characterList)
    {
        var references = Instantiate(model, position, Quaternion.identity).GetComponent<References>();
        references.gameManager = this;
        references.mazeManager = mazeManager;
        playersTransforms.Add(references.transform);
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


    public void GameOver()
    {
        isGameOver = true;
        gameOverObject.active = true;
    }
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
}
