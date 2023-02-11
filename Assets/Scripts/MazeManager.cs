using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public Texture2D mazeImage;
    public GameObject wallModel;
    public GameObject player1Object;
    public GameObject player2Objerct;
    public GameObject enemyObject;
    void Start()
    {
        for (int x = 0; x < mazeImage.width; x++)
        {
            for (int y = 0; y < mazeImage.height; y++)
            {
                if (mazeImage.GetPixel(x, y) == Color.black)
                {
                    Instantiate(wallModel, new Vector3(x, y), Quaternion.identity, transform);
                }
            }
        }
    }
    public bool HasWall(int x, int y)
    {
        return (mazeImage.GetPixel(x, y) == Color.black);
    }
    public bool HasWall(Vector3 coordinate)
    {
        int xInt = Mathf.RoundToInt(coordinate.x);
        int yInt = Mathf.RoundToInt(coordinate.y);
        return HasWall(xInt, yInt);
    }

}
