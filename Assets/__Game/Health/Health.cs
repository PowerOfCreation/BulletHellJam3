using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    public int health = 2;

    public int maxHealth;

    void Awake()
    {
        maxHealth = health;
    }

    void OnDisable()
    {
        health = maxHealth;
    }

    public abstract void Damage(int amount);
}
