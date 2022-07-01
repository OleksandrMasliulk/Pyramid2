using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundAudioClip
{
    [Header("General parameters")]
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    public float repeatPlayeDelay;
    private float lastTimePlayed;

    [Header("3D Sound settings")]
    [Range(0f, 100f)]
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
