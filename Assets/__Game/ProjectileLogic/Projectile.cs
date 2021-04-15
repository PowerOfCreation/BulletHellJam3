using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    public float speed = 8f;

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity.normalized;
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
