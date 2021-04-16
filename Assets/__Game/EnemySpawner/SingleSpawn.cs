using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpawn : SpawnEvent
{
    public EnemyDifficultyEntry enemyDifficultyEntry;

    public SingleSpawn(EnemyDifficultyEntry enemyDifficultyEntry)
    {
        this.enemyDifficultyEntry = enemyDifficultyEntry;
    }

    public override float GetSpawnPriority(float currentDifficulty)
    {
        int indexOfHighestEntry = -1;
        float highestPriority = 0;

        for (int i = 0; i < enemyDifficultyEntry.priorityAtDifficulties.Count; i++)
        {
            if(currentDifficulty < enemyDifficultyEntry.priorityAtDifficulties[i].difficulty)
            {
                break;
            }

            if(enemyDifficultyEntry.priorityAtDifficulties[i].priority > highestPriority)
            {
                highestPriority = enemyDifficultyEntry.priorityAtDifficulties[i].priority;
                indexOfHighestEntry = i;
            }
        }

        return highestPriority;
    }

    public override void Spawn()
    {
        PoolingManager.Spawn(enemyDifficultyEntry.prefab, new Vector3(Random.Range(-ScreenBoundary.screenBoundary.x, ScreenBoundary.screenBoundary.x), Random.Range(5, 6)));
    }
}
