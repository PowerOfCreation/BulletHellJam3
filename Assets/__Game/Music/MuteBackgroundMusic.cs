using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBackgroundMusic : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<AudioSource>().enabled = !GetComponent<AudioSource>().enabled;
        }
    }
}
