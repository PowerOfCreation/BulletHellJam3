using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public SoundEffect playerHitEffect;
    public SoundEffect playerDeathEffect;

    public List<Sprite> damageSprites = new List<Sprite>();

    public override void Damage(int amount)
    {
        health -= amount;

        playerHitEffect.Play(GlobalAudioSource.audioSource);

        if(health <= 0)
        {
            GetComponent<Animator>().SetTrigger("explode");
            playerDeathEffect.Play(GlobalAudioSource.audioSource);
            GetComponent<PlayerMovement>().enabled = false;          
            GetComponent<PlayerShoot>().enabled = false;          
            PauseMenu.Show(true);
            GetComponent<PlayerHealth>().enabled = false;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = damageSprites[maxHealth-health];
        }
    }
}
