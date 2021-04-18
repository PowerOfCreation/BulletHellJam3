using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeNuke : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            NukeParentTransformHolder.self.Charge();
        }
    }
}
