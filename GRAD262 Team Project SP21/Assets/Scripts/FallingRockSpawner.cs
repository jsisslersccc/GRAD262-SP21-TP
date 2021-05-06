using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject rockPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 4f;
    public float nextSpawnTime = 0;
    public Queue<GameObject> rocks = new Queue<GameObject>();
    public int maxQueueSize = 100;

    void Start()
    {
        nextSpawnTime = Time.fixedTime + Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > nextSpawnTime)
        {
            GameObject rock = Instantiate(rockPrefab);
            rocks.Enqueue(rock);
            rock.transform.position = spawnPoint.transform.position;
            nextSpawnTime = Time.fixedTime + Random.Range(minSpawnDelay, maxSpawnDelay);
        }

        if (rocks.Count > maxQueueSize)
        {
            Destroy(rocks.Dequeue());
        }
    }
}
