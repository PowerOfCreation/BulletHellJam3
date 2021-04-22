using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MusicChange : MonoBehaviour
{
    private Slider musicSlider;

    public List<AudioSource> musicAudioSources = new List<AudioSource>();

    public static MusicChange self;

    public float Volume { get => musicSlider.value; }

    void Awake()
    {
        self = this;
        musicSlider = GetComponent<Slider>();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
    }

    public void Change()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);

        for (int i = 0; i < musicAudioSources.Count; i++)
        {
            musicAudioSources[i].volume = musicSlider.value;            
        }
    }
}
