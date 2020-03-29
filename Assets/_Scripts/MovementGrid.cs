using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGrid : MonoBehaviour
{
    public LayerMask unwalkable;
    public int width;
    public int height;

    public float tileWidth;
    public float tileHeight;

    public int originX = 10;
    public int originY = 10;

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
            if (isValidX(value) && !Physics2D.OverlapCircle(new Vector2(value, PlayerY), 0.2f, unwalkable))
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

            if (isValidY(value) && !Physics2D.OverlapCircle(new Vector2(PlayerX, value), 0.2f, unwalkable))
            {
                playerY = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerX = originX;
        playerY = originY;
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

    public void ResetPlayerPosition()
    {
        PlayerX = originX;
        PlayerY = originY;
    }
}
