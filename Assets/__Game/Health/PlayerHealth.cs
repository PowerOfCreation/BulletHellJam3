using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public override void Damage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Debug.Log("hi");
            SceneManager.LoadScene(0);
        }
    }
}
