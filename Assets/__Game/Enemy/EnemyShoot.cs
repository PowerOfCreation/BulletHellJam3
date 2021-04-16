using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootingInterval = 0.5f;

    private float nextTimeToFire = 0f;

    public GameObject projectilePrefab;

    /*void Update()
    {
        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + shootingInterval;

            Fire();
        }
    }*/

    void Fire()
    {
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(transform.up);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize((Quaternion.AngleAxis(15, transform.forward) * transform.up));
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize((Quaternion.AngleAxis(-15, transform.forward) * transform.up));
    }
}
