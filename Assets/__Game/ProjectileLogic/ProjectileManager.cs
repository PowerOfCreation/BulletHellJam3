using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager self;

    [HideInInspector]
    public List<Projectile> projectiles = new List<Projectile>(1000);

    public static int explodeTriggerHash;

    void Awake()
    {
        self = this;
        explodeTriggerHash = Animator.StringToHash("explode");
    }

    void Update()
    {
        Hitscan();
    }


    private void Hitscan()
    {
        for (int i = 0; i < projectiles.Count; i++)
        {
            if(!projectiles[i].isStillAlive) continue;
            
            Collider2D[] results = new Collider2D[10];

            int count = Physics2D.OverlapCircleNonAlloc(projectiles[i].transform.position, projectiles[i].radius, results);

            for (int j = 0; j < count; j++)
            {
                if(projectiles[i].isPlayerOwned)
                {
                    if(results[j].gameObject != Player.self.gameObject)
                    {
                        results[j].GetComponent<IDamageable>()?.Damage(1);
                        projectiles[i].Hit();
                    }
                }
                else
                {
                    if(results[j].gameObject == Player.self.gameObject)
                    {
                        results[j].GetComponent<IDamageable>()?.Damage(1);
                        projectiles[i].Hit();
                    }
                }
            }
        }
    }
}
