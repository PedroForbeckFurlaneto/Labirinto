using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    public float moveInterval;
    private float time = 0f;
    private List<Vector3> directions = new List<Vector3> { Vector3.up, Vector3.down, Vector3.right, Vector3.left };

    public MazeManager mazeManager;
    public GameManager gameManager;
    private Vector3 lastMove;
    void Start()
    {
        lastMove = directions[Random.Range(0, directions.Count)];
    }
    void Update()
    {
        if (gameManager.GetIsGameOver() == true)
        {
            return;
        }
        time += Time.deltaTime;
        if (time >= moveInterval)
        {
            time = 0f;
            CheckMove();
        }
    }
    private void CheckMove()
        // Para o inimigo evitar voltar o ultimo movimento realizado.
    {
        Vector3 oppositeLastMove;
        List<Vector3> directionsTemp = new List<Vector3>();
        directionsTemp.AddRange(directions);
        if (lastMove == Vector3.up)
        {
            oppositeLastMove = Vector3.down;
        }
        else if (lastMove == Vector3.down)
        {
            oppositeLastMove = Vector3.up;
        }
        else if (lastMove == Vector3.left)
        {
            oppositeLastMove = Vector3.right;
        }
        else
        {
            oppositeLastMove = Vector3.left;
        }
        directionsTemp.Remove(oppositeLastMove);
        for (int i = 0; i < directions.Count - 1; i++)
        {
            Vector3 direction = directionsTemp[Random.Range(0, directionsTemp.Count)];
            if (mazeManager.HasWall(transform.position + direction) == false)
            {
                Move(direction);
                return;
            }
            else
            {
                directionsTemp.Remove(direction);
            }
        }
        if (mazeManager.HasWall(transform.position + oppositeLastMove) == false)
        {
            Move(oppositeLastMove);
            return;
        }

        void Move(Vector3 direction)
        {
            lastMove = direction;
            transform.position += direction;
            gameManager.CheckCollision();
        }
    }
}