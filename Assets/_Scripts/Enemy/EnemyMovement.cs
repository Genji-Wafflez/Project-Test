using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, ClockListener
{
    [SerializeField]
    private MovementGrid moveGrid;
    [SerializeField]
    private GameClock clock;
    [SerializeField]
    private Waypoint moveToPoint;
    [SerializeField]
    private float distanceThreshold = 0.01f;
    
    public float speed = 4f;

    private int posX, posY;

    private bool canMove;

    void Awake()
    {
        transform.position = moveToPoint.transform.position;
        posX = moveToPoint.X;
        posY = moveToPoint.Y;
    }

    private void Start()
    {
        clock.registerListener(this);
    }
    void Update()
    {
        if(moveToPoint == null)
        {
            return;
        }

        if(Vector2.Distance(transform.position, moveToPoint.transform.position) <= distanceThreshold)
        {
            moveToPoint = moveToPoint.Next;
        }

        //Move towards grid position
        transform.position += (moveGrid.getPosition(posX, posY) - transform.position) * Time.deltaTime * speed;

        if(canMove)
        {
            MoveInGrid(moveToPoint.X, moveToPoint.Y);

            canMove = false;
        }
    }

    private void MoveInGrid(int destX, int destY)
    {
        int xDiff = destX - posX;
        int yDiff = destY - posY;

        posX += xDiff == 0 ? 0 : xDiff > 0 ? 1 : -1;
        posY += yDiff == 0 ? 0 : yDiff > 0 ? 1 : -1;
    }

    public void Tock()
    {
        canMove = true;
    }
}
