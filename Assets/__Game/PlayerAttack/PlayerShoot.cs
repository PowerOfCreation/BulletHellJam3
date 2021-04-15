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
        PoolingManager.Spawn(playerProjectile, transform.position).GetComponent<Projectile>().SetVelocity(transform.up);
    }
}
