using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public SoundEffect destroyedSoundEffect;

    public List<GameObject> pickups = new List<GameObject>(); 

    public float chance = 0.05f;

    public override void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            if(chance >= Random.Range(0f, 1f))
            {
                GameObject.Instantiate(pickups[Random.Range(0, pickups.Count)], transform.position, Quaternion.identity);
            }

            destroyedSoundEffect.Play(GlobalAudioSource.audioSource);
            PoolingManager.Despawn(gameObject);
        }
    }
}
