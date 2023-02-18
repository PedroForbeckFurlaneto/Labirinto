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

    private Vector3 direction;

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
        switch (status)
        {
            case PlayerStatus.Moving:
                Moving();
                break;
            case PlayerStatus.Stopped:
                break;
        }
    }
    private void Moving()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    private void Move (Vector3 direction) 
    {
        status = PlayerStatus.Moving;
        this.direction = direction;
       //if (references.mazeManager.HasWall(transform.position + direction) == false)
       //{
       //    transform.position += direction;
       //}
    }
}
