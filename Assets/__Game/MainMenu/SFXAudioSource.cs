using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SFXChange.self.sfxAudioSources.Add(GetComponent<AudioSource>());
        GetComponent<AudioSource>().volume = SFXChange.self.Volume;
    }
}
