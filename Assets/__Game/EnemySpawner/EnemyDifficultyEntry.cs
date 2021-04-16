using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PriorityAtDifficulty
{
    public float difficulty;
    public int priority;
}

[CreateAssetMenu(fileName = "EnemyDifficultyEntry", menuName = "Enemy/Enemy Difficulty Entry", order = 1)]
public class EnemyDifficultyEntry : ScriptableObject
{
    public GameObject prefab;
    public List<PriorityAtDifficulty> priorityAtDifficulties = new List<PriorityAtDifficulty>();
}
