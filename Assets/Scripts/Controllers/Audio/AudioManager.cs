using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public enum Sound 
    //{ 
    //    //PlayerWalk,
    //    //MummyWalk,
    //    //PlayerDie,
    //    //PlayerDieFX,
    //    //DoorOpen,
    //    //DoorClose,
    //    LevelTheme, //Music
    //    LowSanity, //Music
    //    NoSanity, //Music
    //    //FireTrap,
    //    //ArrowTrap,
    //    //PickUpItem,
    //    //PickUpTreasure,
    //    //Lever
    //}

    public static AudioManager Instance { get; private set; }

    [SerializeField] private SoundBoardSO[] _soundBoards;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitSoundBoards();
    }

    private void InitSoundBoards()
    {
        foreach (SoundBoardSO sb in _soundBoards)
        {
            sb.SoundBoard.Init();
        }
    }

    public T GetSoundBoard<T>() where T : SoundBoard
    {
        T tmp = new SoundBoard() as T;

        foreach (SoundBoardSO sb in _soundBoards)
        {
            if (typeof(T) == sb.SoundBoard.GetType())
            {
                return (T)sb.SoundBoard;
            }
        }

        return null;
    }

    public AudioSource PlaySound(SoundAudioClip sound)
    {
        AudioClip clip = sound.clip;
        AudioSource audioSource = null;
        if (clip != null && sound.CanPlay())
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.volume = sound.volume;
            audioSource.PlayOneShot(clip);
        }

        return audioSource;
    }

    public AudioSource PlaySound(SoundAudioClip sound, bool looped)
    {
        AudioClip clip = sound.clip;
        AudioSource audioSource = null;
        if (clip != null && sound.CanPlay())
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.loop = looped;
            audioSource.volume = sound.volume;
            audioSource.Play();
        }

        return audioSource;
    }

    public AudioClip PlaySound(SoundAudioClip sound, Vector3 position)
    {
        AudioClip clip = sound.clip;
        if (clip != null && sound.CanPlay())
        {
            GameObject go = new GameObject("Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = sound.volume;
            audioSource.maxDistance = sound.maxRange;
            audioSource.Play();
        }

        return clip;
    }
    public AudioSource PlaySound(SoundAudioClip sound, float playbackTime)
    {
        AudioClip clip = sound.clip;
        AudioSource audioSource = null;
        if (clip != null && sound.CanPlay())
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.volume = sound.volume;
            audioSource.PlayOneShot(clip);

            MonoBehaviour.Destroy(audioSource.gameObject, playbackTime);
        }

        return audioSource;
    }
    
    public AudioSource PlaySound(SoundAudioClip sound, Vector3 position, float playbackTime)
    {
        AudioClip clip = sound.clip;
        AudioSource audioSource = null;
        if (clip != null && sound.CanPlay())
        {
            GameObject go = new GameObject("Sound");
            audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = sound.volume;
            audioSource.maxDistance = sound.maxRange;
            audioSource.Play();

            MonoBehaviour.Destroy(audioSource.gameObject, playbackTime);
        }

        return audioSource;
    }

}
