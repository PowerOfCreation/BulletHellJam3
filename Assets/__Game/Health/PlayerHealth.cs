using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public SoundEffect playerHitEffect;
    public SoundEffect playerDeathEffect;

    public List<Sprite> damageSprites = new List<Sprite>();

    private int maxHealth;

    void Awake()
    {
        maxHealth = health;
    }

    public override void Damage(int amount)
    {
        health -= amount;

        playerHitEffect.Play(GlobalAudioSource.audioSource);

        if(health <= 0)
        {
            playerDeathEffect.Play(GlobalAudioSource.audioSource);            
            PauseMenu.Show(true);
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = damageSprites[maxHealth-health];
        }
    }
}
