using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlobalAudioSource : MonoBehaviour
{
    public static GlobalAudioSource self;

    public static AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        self = this;
        audioSource = GetComponent<AudioSource>();
    }
}
