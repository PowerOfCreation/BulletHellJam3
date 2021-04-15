using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager self;

    [HideInInspector]
    public List<Projectile> projectiles = new List<Projectile>(1000);

    void Awake()
    {
        self = this;
    }

    void Update()
    {
        Hitscan();
    }

    private void Hitscan()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            Collider2D[] results = new Collider2D[10];

            int count = Physics2D.OverlapCircleNonAlloc(projectiles[i].transform.position, projectiles[i].radius, results);

            for (int j = 0; j < count; j++)
            {
                results[j].GetComponent<IDamageable>()?.Damage(1);
            }
        }
    }
}
