using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalEnemyLogic : TurretEnemyLogic
{
    protected override void SpawnProjectiles()
    {
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(1, 0).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(0, 1).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(-1, 0).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(0, -1).normalized);
    }
}
