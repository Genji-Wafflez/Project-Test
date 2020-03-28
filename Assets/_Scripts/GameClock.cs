using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{
    public float timeInterval = 1f;
    public float clock = 0f;

    private List<ClockListener> clockListeners = new List<ClockListener>();

    private void Update()
    {
        clock += Time.deltaTime;

        if(clock >= timeInterval)
        {
            clock = 0f;
            Tick();
        }
    }
    public void registerListener(ClockListener clockListener)
    {
        clockListeners.Add(clockListener);
    }
    public void removeListener(ClockListener clockListener)
    {
        clockListeners.Remove(clockListener);
    }
    private void Tick()
    {
        Debug.Log("Tick");
        foreach(ClockListener cl in clockListeners)
        {
            cl.Tock();
        }
    }
}
