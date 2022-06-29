using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAssets : MonoBehaviour
{
    //public static AudioAssets Instance { get; private set; }

    //public SoundAudioClip[] sounds;

    //public SoundBoard[] soundBoards;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //public T GetSoundBoard<T>() where T : SoundBoard
    //{
    //    T tmp = null;

    //    foreach (SoundBoard sb in soundBoards)
    //    {
    //        if (sb.GetType() == tmp.GetType())
    //        {
    //            return (T)sb;
    //        }
    //    }

    //    return null;
    //}

    //public AudioClip GetAudioClip(AudioManager.Sound sound)
    //{
    //    foreach (SoundAudioClip sac in sounds)
    //    {
    //        if (sac.sound == sound)
    //        {
    //            return sac.clip;
    //        }
    //    }

    //    Debug.LogError("No Audio Clip Found!");
    //    return null;
    //}

    //public float GetSoundVolume(AudioManager.Sound sound)
    //{
    //    foreach (SoundAudioClip sac in sounds)
    //    {
    //        if (sac.sound == sound)
    //        {
    //            return sac.volume;
    //        }
    //    }

    //    Debug.LogError("Invalid data!");
    //    return 0f;
    //}

    //[System.Serializable]
    //public class SoundAudioClip
    //{
    //    public AudioManager.Sound sound;
    //    public AudioClip clip;
    //    [Range(0f, 1f)]
    //    public float volume;
    //}
}
