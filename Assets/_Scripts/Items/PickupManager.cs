using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource pickUpSound;

    [SerializeField]
    private List<GameObject> items;

    public bool IsEmpty 
    {
        get
        {
            return items?.Count == 0;
        }
    }
    private void Start()
    {
        PlaceNextItem();
    }
    public void PlaceNextItem()
    {
        if (items.Count < 1)
            return;

        GameObject nextItem = items[0];
        nextItem.SetActive(true);
        items.RemoveAt(0);
    }

    public void PlayPickupSound()
    {
        pickUpSound.Play();
    }
}
