using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid : MonoBehaviour
{
    public GameObject tile;
    public int width;
    public int height;

    public float tileWidth;
    public float tileHeight;

    public GameObject[,] grid;

    public Vector3 PlayerPosition
    {
        get
        {
            return getPosition(PlayerX, PlayerY);
        }
    }
    private int playerX;
    public int PlayerX 
    {
        get 
        {
            return playerX;
        }

        set 
        {
            if(isValidX(value))
            {
                playerX = value;
            }
        }
    }
    private int playerY;
    public int PlayerY
    {
        get
        {
            return playerY;
        }

        set
        {
            if (isValidY(value))
            {
                playerY = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[height,width];

        for(int row = 0; row < height; row++)
        {
            for(int col = 0; col < width; col++)
            {
                float x = col * tileWidth;
                float y = row * tileHeight;

                grid[row, col] = Instantiate(tile, new Vector2(x, y), Quaternion.Euler(0,0,0));
            }
        }

        playerX = width / 2;
        playerY = height / 2;
    }

    public Vector3 getPosition(int x, int y)
    {
        if(!isValidX(x) || !isValidY(y))
        {
            Debug.LogError("Attempt to access tile out of range");
            return new Vector3(-1, -1);
        }

        return new Vector3(x * tileWidth, y * tileHeight);
    }

    private bool isValidX(int x)
    {
        return 0 <= x && x < width;
    }
    private bool isValidY(int y)
    {
        return 0 <= y && y < height;
    }
}
