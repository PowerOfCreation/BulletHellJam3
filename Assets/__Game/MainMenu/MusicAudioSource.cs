using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicChange.self.musicAudioSources.Add(GetComponent<AudioSource>());
        GetComponent<AudioSource>().volume = MusicChange.self.Volume;
    }
}
