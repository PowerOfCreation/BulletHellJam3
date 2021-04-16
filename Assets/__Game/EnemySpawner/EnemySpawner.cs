using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;

    public float spawnInterval = .5f;

    private float nextTimeToSpawn = 0f;

    int lastSpawnPosition = 0;

    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + spawnInterval;

            Spawn();
        }
    }

    public void Start()
    {
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            PoolingManager.AddPrefabToPooling(enemyPrefabs[i]);
        }
    }

    void Spawn()
    {
        PoolingManager.Spawn(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], new Vector3(Random.Range(-ScreenBoundary.screenBoundary.x, ScreenBoundary.screenBoundary.x), Random.Range(3, 5)));
    }
}
