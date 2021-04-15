using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject playerProjectile;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject spawnedProjectile = PoolingManager.Spawn(playerProjectile, ProjectileManager.self.transform);
        spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.GetComponent<Projectile>().SetVelocity(transform.up);
    }
}
