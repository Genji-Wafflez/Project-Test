using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 5f;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer >= spawnInterval)
        {
            GameObject enemy= Instantiate(gameObject, null);

            spawnTimer = 0f;
        }

        spawnTimer += Time.deltaTime;
    }
}
