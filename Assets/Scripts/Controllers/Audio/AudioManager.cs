using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public enum Sound 
    { 
        PlayerWalk,
        MummyWalk,
        PlayerDie,
        PlayerDieFX,
        DoorOpen,
        DoorClose,
        LevelTheme,
        LowSanity,
        NoSanity,
        FireTrap,
        ArrowTrap,
        PickUpItem,
        PickUpTreasure,
        Lever
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Init()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.PlayerWalk] = 0f;
        soundTimerDictionary[Sound.MummyWalk] = 0f;
    }

    public static AudioSource PlaySound(Sound sound)
    {
        AudioClip clip = AudioAssets.Instance.GetAudioClip(sound);
        AudioSource audioSource = null;
        if (clip != null && CanPlaySound(sound))
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.volume = AudioAssets.Instance.GetSoundVolume(sound);
            audioSource.PlayOneShot(clip);
        }

        return audioSource;
    }

    public static AudioSource PlaySound(Sound sound, bool looped)
    {
        AudioClip clip = AudioAssets.Instance.GetAudioClip(sound);
        AudioSource audioSource = null;
        if (clip != null && CanPlaySound(sound))
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.loop = looped;
            audioSource.volume = AudioAssets.Instance.GetSoundVolume(sound);
            audioSource.Play();
        }

        return audioSource;
    }

    public static AudioClip PlaySound(Sound sound, Vector3 position)
    {
        AudioClip clip = AudioAssets.Instance.GetAudioClip(sound);
        if (clip != null && CanPlaySound(sound))
        {
            GameObject go = new GameObject("Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = AudioAssets.Instance.GetSoundVolume(sound);
            audioSource.Play();
        }

        return clip;
    }
    public static AudioSource PlaySound(Sound sound, float playbackTime)
    {
        AudioClip clip = AudioAssets.Instance.GetAudioClip(sound);
        AudioSource audioSource = null;
        if (clip != null && CanPlaySound(sound))
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.volume = AudioAssets.Instance.GetSoundVolume(sound);
            audioSource.PlayOneShot(clip);

            MonoBehaviour.Destroy(audioSource.gameObject, playbackTime);
        }

        return audioSource;
    }
    
    public static AudioSource PlaySound(Sound sound, Vector3 position, float playbackTime)
    {
        AudioClip clip = AudioAssets.Instance.GetAudioClip(sound);
        AudioSource audioSource = null;
        if (clip != null && CanPlaySound(sound))
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = AudioAssets.Instance.GetSoundVolume(sound);
            audioSource.Play();

            MonoBehaviour.Destroy(audioSource.gameObject, playbackTime);
        }

        return audioSource;
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound) 
        {
            default:
                return true;
            case Sound.PlayerWalk:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = .2f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
            case Sound.MummyWalk:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float maxTimer = 1f;
                    if (lastTimePlayed + maxTimer < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                break;
        }
    }
}
