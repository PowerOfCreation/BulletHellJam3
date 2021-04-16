using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public SoundEffect playerHitEffect;

    public override void Damage(int amount)
    {
        health -= amount;

        playerHitEffect.Play(GlobalAudioSource.audioSource);

        if(health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
