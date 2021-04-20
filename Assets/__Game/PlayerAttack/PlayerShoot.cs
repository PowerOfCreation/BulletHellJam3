using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerShoot : MonoBehaviour
{
    public GameObject playerProjectile;
    public GameObject upgradedProjectile;

    public SoundEffect soundEffect;

    private AudioSource audioSource;

    private float shootInterval = 0.1f;

    private float nextTimeFireReady = 0f;

    private List<Vector3> bulletSpawnPositions = new List<Vector3>() { Vector3.right * 0.3f, Vector3.left * 0.3f};

    public int upgradeLevel = 0;

    public float upgradeDuration = 10f;
    public float upgradeExpiresAt = 10f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(ChargeNuke.isCharging) return;
        
        if(Input.GetButton("Fire1") && Time.time >= nextTimeFireReady)
        {
            nextTimeFireReady = Time.time + shootInterval;
            Fire();
        }

        if(upgradeLevel > 0 && Time.time >= upgradeExpiresAt)
        {
            upgradeLevel = 0;
        }
    }

    private void Fire()
    {
        for (int i = 0; i < bulletSpawnPositions.Count; i++)
        {
            FireBulletSpawnPosition(bulletSpawnPositions[i]);
        }

        soundEffect.Play(audioSource);
    }

    private void FireBulletSpawnPosition(Vector3 position)
    {
        GameObject spawnedProjectile = PoolingManager.Spawn(playerProjectile, transform.position + position);
        spawnedProjectile.GetComponent<Projectile>().Initialize(Vector3.up);

        if(upgradeLevel == 0) return;

        float anglePerUpgradeLevel = (Mathf.PI / 2f) / (upgradeLevel + 1);

        for (int i = 1; i < upgradeLevel + 1; i++)
        {
            spawnedProjectile = PoolingManager.Spawn(upgradedProjectile, transform.position + position);
            spawnedProjectile.GetComponent<Projectile>().Initialize(new Vector3(Mathf.Cos(anglePerUpgradeLevel * i), Mathf.Sin(anglePerUpgradeLevel * i)));
            spawnedProjectile = PoolingManager.Spawn(upgradedProjectile, transform.position + position);
            spawnedProjectile.GetComponent<Projectile>().Initialize(new Vector3(-Mathf.Cos(anglePerUpgradeLevel * i), Mathf.Sin(anglePerUpgradeLevel * i)));
        }
    }

    public void Upgrade()
    {
        upgradeLevel++;
        upgradeExpiresAt = Time.time + upgradeDuration;
    }
}
