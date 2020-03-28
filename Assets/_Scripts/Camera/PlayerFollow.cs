using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothing = 3.14f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(target.position + offset, transform.position, Time.deltaTime * smoothing);
    }
}
