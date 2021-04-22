using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public SoundEffect soundEffect;

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject == Player.self.gameObject)
        {
            soundEffect.Play(GlobalAudioSource.audioSource);
            OnPickup(Player.self);
            Destroy(gameObject);
        }
    }

    public abstract void OnPickup(Player player);

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, 0);
        if(transform.position.y < -5) Destroy(gameObject);
    }
}

