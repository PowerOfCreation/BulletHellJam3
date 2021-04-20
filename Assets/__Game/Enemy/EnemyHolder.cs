using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    public static EnemyHolder self;

    public void Awake()
    {
        self = this;
    }
}
