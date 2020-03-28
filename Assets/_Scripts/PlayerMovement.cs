using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ClockListener
{
    public MovementGrid moveGrid;
    public GameClock clock;

    public float tileDistanceThreshold = 0.1f;

    public int tileMoveDistance = 1;
    public float moveToSpeed = 10f;

    private enum Direction { None, Up, Down, Left, Right }
    private bool canMove = true;
    private Direction curDirection = Direction.None;

    void Start()
    {
        clock.registerListener(this);
    }

    void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(inputVector.x == 1)
        {
            curDirection = Direction.Right;
        }
        else if (inputVector.x == -1)
        {
            curDirection = Direction.Left;
        }
        else if (inputVector.y == 1)
        {
            curDirection = Direction.Up;
        }
        else if(inputVector.y == -1)
        {
            curDirection = Direction.Down;
        }

        if (canMove)
        {
            switch(curDirection)
            {
                case Direction.Right:
                    moveGrid.PlayerX += tileMoveDistance;
                    break;
                case Direction.Left:
                    moveGrid.PlayerX -= tileMoveDistance;
                    break;
                case Direction.Up:
                    moveGrid.PlayerY += tileMoveDistance;
                    break;
                case Direction.Down:
                    moveGrid.PlayerY -= tileMoveDistance;
                    break;
            }

            canMove = false;
        }

        transform.position += (moveGrid.PlayerPosition - transform.position) * Time.deltaTime * moveToSpeed;        
    }

    public void Tock()
    {
        canMove = true;
    }
}
