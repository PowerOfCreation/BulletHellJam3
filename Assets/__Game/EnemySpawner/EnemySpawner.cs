using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyDifficultyEntry> enemyDifficultyEntries = new List<EnemyDifficultyEntry>();

    private List<SpawnEvent> spawnEvents = new List<SpawnEvent>();

    public float difficulty = 0f;
    public float difficultyIncreasePerSecond = 1f;

    public float nextEventInterval = 1f;
    public float nextEventAtTime = 0.5f;

    SpawnEvent[] possibleSpawnEvents = new SpawnEvent[50];

    void Update()
    {
        difficulty += difficultyIncreasePerSecond * Time.deltaTime;

        if(Time.time >= nextEventAtTime)
        {
            nextEventAtTime = Time.time + nextEventInterval;

            float totalSpawnPriority = 0f;
            int possibleSpawnEventsCount = 0;

            for (int i = 0; i < spawnEvents.Count; i++)
            {
                float spawnPriority = spawnEvents[i].GetSpawnPriority(difficulty);
                
                if(spawnPriority >= 0.01f)
                {
                    totalSpawnPriority += spawnPriority;
                    possibleSpawnEvents[possibleSpawnEventsCount] = spawnEvents[i];
                    possibleSpawnEventsCount++;
                }
            }
            
            float randomlyDecidedSpawn = Random.Range(0f, totalSpawnPriority);

            totalSpawnPriority = 0f;

            for (int i = 0; i < possibleSpawnEventsCount; i++)
            {
                Debug.Log(possibleSpawnEvents[i].enemyDifficultyEntry.prefab + "" + possibleSpawnEvents[i].GetSpawnPriority(difficulty));

                totalSpawnPriority += possibleSpawnEvents[i].GetSpawnPriority(difficulty);

                if(randomlyDecidedSpawn <= totalSpawnPriority)
                {
                    possibleSpawnEvents[i].Spawn();
                    break;
                }
            }
        }
    }

    public void Start()
    {
        for (int i = 0; i < enemyDifficultyEntries.Count; i++)
        {
            PoolingManager.AddPrefabToPooling(enemyDifficultyEntries[i].prefab);
            spawnEvents.Add(new SingleSpawn(enemyDifficultyEntries[i]));
        }

        for (int i = 0; i < enemyDifficultyEntries.Count; i++)
        {
            spawnEvents.Add(new CircleSpawn(enemyDifficultyEntries[i], 0.5f, 4));
        }

        for (int i = 0; i < enemyDifficultyEntries.Count; i++)
        {
            spawnEvents.Add(new CircleSpawn(enemyDifficultyEntries[i], 0.8f, 6));
        }

        for (int i = 0; i < enemyDifficultyEntries.Count; i++)
        {
            spawnEvents.Add(new CircleSpawn(enemyDifficultyEntries[i], 1, 8));
        }
    }
}
