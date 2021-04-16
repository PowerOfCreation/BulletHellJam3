using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    public int health = 2;

    public abstract void Damage(int amount);
}
