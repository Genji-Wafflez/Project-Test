using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public int X;
    public int Y;

    public float chanceToSwitchPaths = 0.2f;

    [SerializeField]
    private  Waypoint next;

    [SerializeField]
    private  Waypoint chanceNext;

    private MovementGrid moveGrid;

    public void Start()
    {
        moveGrid = FindObjectOfType<MovementGrid>();
        transform.position = moveGrid.getPosition(X, Y);
    }
    public Waypoint Next
    {
        get
        {
            if(chanceNext != null && Random.value <= chanceToSwitchPaths)
            {
                return chanceNext;
            }

            return next;
        }
    }

    void OnDrawGizmosSelected()
    {
        //transform.position = new Vector2(X, Y);

        if (next != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, next.transform.position);
        }

        if (chanceNext != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, chanceNext.transform.position);


        }
    }
}
