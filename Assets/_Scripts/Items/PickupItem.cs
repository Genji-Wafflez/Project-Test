using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private PickupManager puManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puManager.PlaceNextItem();
        puManager.PlayPickupSound();
        Destroy(gameObject);
    }
}
