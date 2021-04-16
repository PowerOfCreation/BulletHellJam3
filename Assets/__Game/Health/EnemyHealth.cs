using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public SoundEffect destroyedSoundEffect;

    public override void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            destroyedSoundEffect.Play(GlobalAudioSource.audioSource);
            PoolingManager.Despawn(gameObject);
        }
    }
}
