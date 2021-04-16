using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public List<Transform> spawnPositions = new List<Transform>();

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
        PoolingManager.AddPrefabToPooling(enemyPrefab);
    }

    void Spawn()
    {
        PoolingManager.Spawn(enemyPrefab, spawnPositions[lastSpawnPosition++ %  spawnPositions.Count].position);
    }
}
