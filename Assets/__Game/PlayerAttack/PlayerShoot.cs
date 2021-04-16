using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerShoot : MonoBehaviour
{
    public GameObject playerProjectile;

    public SoundEffect soundEffect;

    private AudioSource audioSource;

    private float shootInterval = 0.1f;

    private float nextTimeFireReady = 0f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeFireReady)
        {
            nextTimeFireReady = Time.time + shootInterval;
            Fire();
        }
    }

    private void Fire()
    {
        GameObject spawnedProjectile = PoolingManager.Spawn(playerProjectile, transform.position);
        spawnedProjectile.GetComponent<Projectile>().Initialize(Vector3.up);
        soundEffect.Play(audioSource);
    }
}
