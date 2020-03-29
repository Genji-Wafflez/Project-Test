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
            GameObject enemy= Instantiate(gameObject, transform.position, transform.rotation);

            Destroy(enemy.GetComponent<EnemyMovement>());
            enemy.GetComponent<EnemyMovement>().GetCopyOf<EnemyMovement>(GetComponent<EnemyMovement>());

            spawnTimer = 0f;
        }

        spawnTimer += Time.deltaTime;
    }
}
