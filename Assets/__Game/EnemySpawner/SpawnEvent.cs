using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnEvent
{
    public EnemyDifficultyEntry enemyDifficultyEntry;
    
    public abstract float GetSpawnPriority(float currentDifficulty);
    public abstract void Spawn();
}
