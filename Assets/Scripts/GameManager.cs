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

    public bool stopGame = false;

    bool isGameOver = false;
    private void Start()
    {
        gameOverObject.active = false;
        CharacterInstantiate(player1Model, player1Position.position, playersTransforms);
        switch (MenuManager.shared.gameMode)
        {
            case GameMode.SinglePlayer:
                CharacterInstantiate(enemyModel, enemyPosition.position, enemiesTransforms);
                break;
            case GameMode.MultiPlayer:
                CharacterInstantiate(player2Model, player2Position.position, playersTransforms);
                break;
        }
    }

    private void CharacterInstantiate(GameObject model, Vector3 position, List<Transform> characterList)
    {
        var references = Instantiate(model, position, Quaternion.identity).GetComponent<References>();
        references.gameManager = this;
        references.mazeManager = mazeManager;
        playersTransforms.Add(references.transform);
    }
    public void PlayerCollision()
    {
        GameOver();
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
