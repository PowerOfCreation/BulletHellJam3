using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : SpawnEvent
{
    protected float radius;
    protected int amount;

    public CircleSpawn(EnemyDifficultyEntry enemyDifficultyEntry, float radius = 1f, int amount = 4)
    {
        this.enemyDifficultyEntry = enemyDifficultyEntry;
        this.radius = radius;
        this.amount = amount;
    }

    public override float GetSpawnPriority(float currentDifficulty)
    {
        int indexOfHighestEntry = -1;
        float highestPriority = 0;

        for (int i = 0; i < enemyDifficultyEntry.priorityAtDifficulties.Count; i++)
        {
            if(currentDifficulty < enemyDifficultyEntry.priorityAtDifficulties[i].difficulty * amount * 2f)
            {
                break;
            }

            if(enemyDifficultyEntry.priorityAtDifficulties[i].priority > highestPriority)
            {
                highestPriority = enemyDifficultyEntry.priorityAtDifficulties[i].priority;
                indexOfHighestEntry = i;
            }
        }

        return (highestPriority / ((float) amount * 2f));
    }

    public override void Spawn()
    {
        Vector3 centerPoint = new Vector3(Random.Range(-ScreenBoundary.screenBoundary.x + radius, ScreenBoundary.screenBoundary.x - radius), Random.Range(5f, 9.7f));

        float rotationPerEnemy = (Mathf.PI * 2) / amount;

        for (int i = 0; i < amount; i++)
        {
            PoolingManager.Spawn(enemyDifficultyEntry.prefab, centerPoint + new Vector3(Mathf.Cos(rotationPerEnemy * i), Mathf.Sin(rotationPerEnemy * i)).normalized * radius, EnemyHolder.self.transform);
        }
    }
}
