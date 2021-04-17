using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject == Player.self.gameObject)
        {
            OnPickup(Player.self);
            Destroy(gameObject);
        }
    }

    public abstract void OnPickup(Player player);
}

