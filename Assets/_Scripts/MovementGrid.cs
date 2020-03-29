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
            Collider2D collider = Physics2D.OverlapBox(new Vector2(value, PlayerY), Vector2.one, 0f, LayerMask.GetMask("Unwalkable"));
            if (isValidX(value) && collider == null)
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
            Collider2D collider = Physics2D.OverlapBox(new Vector2(playerX, value), Vector2.one, 0f, LayerMask.GetMask("Unwalkable"));
            if (isValidY(value) && collider == null)
            {
                playerY = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerX = 10;//width / 2;
        playerY = 10;//height / 2;
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
