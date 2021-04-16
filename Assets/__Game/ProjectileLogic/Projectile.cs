using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    public float speed = 8f;

    public float radius = 0.5f;

    public bool isPlayerOwned = false;

    public void OnEnable()
    {
        ProjectileManager.self.projectiles.Add(this);
    }

    public void OnDisable()
    {
        ProjectileManager.self.projectiles.Remove(this);
    }

    public void Initialize(Vector3 velocity, bool isPlayerOwned = false)
    {
        this.velocity = velocity.normalized;
        this.isPlayerOwned = isPlayerOwned;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime * speed;

        if(transform.position.x < -ScreenBoundary.screenBoundary.x || transform.position.x > ScreenBoundary.screenBoundary.x)
        {
            PoolingManager.Despawn(gameObject);
        }
        else if(transform.position.y < -ScreenBoundary.screenBoundary.y || transform.position.y > ScreenBoundary.screenBoundary.y)
        {
            PoolingManager.Despawn(gameObject);
        }
    }
}
