using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class SoundAudioClip
{
    public enum SoundType 
    {
        Sound,
        Music
    }

    [Header("General parameters")]
    public SoundType type;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public float repeatPlayeDelay;
    private float lastTimePlayed;

    [Header("3D Sound settings")]
    [Range(1f, 100f)]
    public float maxRange;

    public void Init() 
    {
        lastTimePlayed = Time.time;
    }

    public bool CanPlay()
    {
        if (repeatPlayeDelay == 0)
        {
            return true;
        }

        if (lastTimePlayed + repeatPlayeDelay < Time.time)
        {
            lastTimePlayed = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
}
