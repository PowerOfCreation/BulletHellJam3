using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "Audio/Sound Effect", order = 1)]
public class SoundEffect : ScriptableObject
{
    public List<SoundClip> soundClips = new List<SoundClip>();

    public AudioClip Play(AudioSource audioSource, bool oneShot = true)
    {
        var pickedSoundClip = soundClips[Random.Range(0, soundClips.Count)];

        if(!oneShot)
        {
            audioSource.clip = pickedSoundClip.clip;
            audioSource.volume = Random.Range(pickedSoundClip.volumeRange.x, pickedSoundClip.volumeRange.y);
            audioSource.Play();

            return pickedSoundClip.clip;
        }

        return pickedSoundClip.Play(audioSource);
    }
}

[System.Serializable]
public class SoundClip
{
    public AudioClip clip;
    public Vector2 volumeRange;

    public AudioClip Play(AudioSource audioSource)
    {
        audioSource.PlayOneShot(clip, Random.Range(volumeRange.x, volumeRange.y));

        return clip;
    }
}