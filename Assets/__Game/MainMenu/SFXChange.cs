using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SFXChange : MonoBehaviour
{
    private Slider sfxSlider;

    public List<AudioSource> sfxAudioSources = new List<AudioSource>();

    public static SFXChange self;

    public float Volume { get => sfxSlider.value; }

    void Awake()
    {
        self = this;
        sfxSlider = GetComponent<Slider>();
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1f);
    }

    public void Change()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);

        for (int i = 0; i < sfxAudioSources.Count; i++)
        {
            sfxAudioSources[i].volume = sfxSlider.value;            
        }
    }
}
