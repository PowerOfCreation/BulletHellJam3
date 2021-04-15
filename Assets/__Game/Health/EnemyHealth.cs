using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Damage(int amount)
    {
        Destroy(gameObject);
    }
}
