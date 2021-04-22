using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Projectile : MonoBehaviour
{
    private Animator animator;

    private Vector3 velocity = Vector3.zero;

    public float speed = 8f;

    public float radius = 0.5f;

    public bool isPlayerOwned = false;

    public bool isStillAlive = true;

    public void OnEnable()
    {
        ProjectileManager.self.projectiles.Add(this);
        isStillAlive = true;
    }

    public void OnDisable()
    {
        ProjectileManager.self.projectiles.Remove(this);
    }

    public void Initialize(Vector3 velocity)
    {
        this.velocity = velocity.normalized;
    }

    public void Initialize(Vector3 velocity, bool isPlayerOwned)
    {
        this.velocity = velocity.normalized;
        this.isPlayerOwned = isPlayerOwned;
    }

    public void Death()
    {
        PoolingManager.Despawn(gameObject);
    }

    public void Hit()
    {
        isStillAlive = false;
        animator.SetTrigger(ProjectileManager.explodeTriggerHash);
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

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
