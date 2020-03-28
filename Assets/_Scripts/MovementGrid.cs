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

    public GameObject PlayerTile
    {
        get
        {
            return grid[PlayerY, PlayerX];
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
            if(0 <= value && value < width)
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
            if (0 <= value && value < height)
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
    }
}
