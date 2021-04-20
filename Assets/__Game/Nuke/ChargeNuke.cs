using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeNuke : MonoBehaviour
{
    public static bool isCharging = false;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if(NukeParentTransformHolder.self.Charge())
            {
                isCharging = true;
            }
            else
            {
                isCharging = false;
            }
        }
        else
        {
            isCharging = false;
        }

        if(Input.GetMouseButtonDown(1))
        {
            NukeParentTransformHolder.self.Nuke();
        }
    }
}
