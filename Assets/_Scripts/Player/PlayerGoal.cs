using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    [SerializeField]
    private PickupManager puManager;

    private bool CanWin
    {
        get
        {
            return puManager.IsEmpty;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CanWin && collision.CompareTag("The Almighty"))
        {
            gameObject.GetComponent<PlayerMovement>().IsFrozen = true;

            Destroy(collision.gameObject);
        }
    }
}
