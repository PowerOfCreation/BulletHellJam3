using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public SoundEffect playerHitEffect;

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
            SceneManager.LoadScene(0);
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = damageSprites[maxHealth-health];
        }
    }
}
