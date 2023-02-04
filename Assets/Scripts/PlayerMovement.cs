using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public MazeManager mazeManager;
    public GameManager gameManager;

    void Start()
    {

    }

    void Update()
    {
        if (gameManager.GetIsGameOver() == true)
        {
            return;
        }
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
    private void Move (Vector3 direction) 
    {
        if (mazeManager.HasWall(transform.position + direction) == false)
        {
            transform.position += direction;
            gameManager.CheckCollision();
        }
    }
}
