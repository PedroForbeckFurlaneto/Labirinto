using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus {
    Moving,
    Stopped,
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    private Vector3 currentDirection;
    private List<Vector3> directions = new List<Vector3> ();
    private Vector3 target;

    public PlayerStatus status = PlayerStatus.Stopped;

    public References references;

    void Start()
    {
        
    }

    void Update()
    {
        if (references.gameManager.GetIsGameOver() == true)
        {
            return;
        }
        ReadKeys();
        switch (status)
        {
            case PlayerStatus.Moving:
                Moving();
                break;
            case PlayerStatus.Stopped:
                Stopped();
                break;
        }
    }
    private void Stopped()
    {
        //Não faz nada.
    }
    private void AddDirection(Vector3 direction)
    {
        directions.Add(direction);
        if (directions.Count == 1)
        {
            target = transform.position + direction;
            currentDirection = direction;
        }
    }
    private void ReadKeys()
    {
        if (Input.GetKeyDown(left))
        {
            Move(Vector3.left);
        }
        if (Input.GetKeyDown(right))
        {
            Move(Vector3.right);
        }
        if (Input.GetKeyDown(up))
        {
            Move(Vector3.up);
        }
        if (Input.GetKeyDown(down))
        {
            Move(Vector3.down);
        }
    }
    private void Moving()
    {
        if (directions.Count == 0)
        {
            return;
        }
        Vector3 displacement = currentDirection * Time.deltaTime * speed;
        Vector3 remaining = target - transform.position;
        if (remaining.sqrMagnitude > displacement.sqrMagnitude)
        {
            // Anda
            transform.position += displacement;
        }
        else
        {
            // Chegou no target
            // Verifica se tem diração na fila
            if (directions.Count == 1)
            {
                if (references.mazeManager.HasWall(target + currentDirection) == false)
                {
                    target += currentDirection;
                    transform.position += displacement;
                    return;
                }
                directions.Clear();
                transform.position = target;
                status = PlayerStatus.Stopped;
                return;
            }
            // Verifica se pode andar na proxima diração
            if (references.mazeManager.HasWall(target + directions[1]))
            {
                transform.position = target;
                status = PlayerStatus.Stopped;
                directions.Clear();
                return;
            }
            // Continua na mesma direção
            if (directions[0] == directions[1])
            {
                directions.RemoveAt(0);
                target += directions[0];
                transform.position += displacement;
                return;
            }
            // Muda de direção
            directions.RemoveAt(0);
            currentDirection = directions[0];
            transform.position = target;
            target += currentDirection;

        }
    }
    private void Move (Vector3 direction) 
    {

        if (directions.Count == 0)
        {
            if (references.mazeManager.HasWall(transform.position + direction))
            {
                return;
            }
            currentDirection = direction;
            target = transform.position + direction;
        }
        directions.Add(direction);
        status = PlayerStatus.Moving;
    }
}