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

    [System.Serializable]
    private struct MusicTheme 
    {
        public AudioSource source;
        public float volume;

        public MusicTheme(AudioSource _source, float _volume)
        {
            source = _source;
            volume = _volume;
        }
    }

    [SerializeField] private SoundBoardSO[] _soundBoards;

    [SerializeField] private float _fadeTime;
    [SerializeField]private MusicTheme _levelThemePlaying;
    [SerializeField]private List<MusicTheme> _overlapThemeList;

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
        _overlapThemeList = new List<MusicTheme>();
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
            float duration = clip.length;
            Destroy(audioSource.gameObject, duration);
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
            go.transform.position = position;
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = sound.volume;
            audioSource.spatialBlend = 1;
            //audioSource.rolloffMode = AudioRolloffMode.Custom;
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
            go.transform.position = position;
            audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = sound.volume;
            audioSource.spatialBlend = 1;
            //audioSource.rolloffMode = AudioRolloffMode.Custom;
            audioSource.maxDistance = sound.maxRange;
            audioSource.Play();

            MonoBehaviour.Destroy(audioSource.gameObject, playbackTime);
        }

        return audioSource;
    }

    public void PlayLevelTheme(SoundAudioClip sound)
    {
        //StopAllCoroutines();

        if (_levelThemePlaying.source == null)
        {
            _levelThemePlaying = new MusicTheme(PlaySound(sound, true), sound.volume);
            StartCoroutine(FadeIn(_levelThemePlaying));
        }
        else
        {
            AudioSource oldTheme = _levelThemePlaying.source;
            _levelThemePlaying = new MusicTheme(PlaySound(sound, true), sound.volume);
            StartCoroutine(FadeOut(oldTheme, true));
            StartCoroutine(FadeIn(_levelThemePlaying));
        }

    }

    public void PlayOverlapTheme(SoundAudioClip sound)
    {
        if (FindThemeByClip(sound.clip).source != null)
            return;

        //StopAllCoroutines();

        _overlapThemeList.Add(new MusicTheme(PlaySound(sound, true), sound.volume));
        if (_overlapThemeList.Count <= 1)
        {
            StartCoroutine(FadeIn(_overlapThemeList[_overlapThemeList.Count - 1]));
            StartCoroutine(FadeOut(_levelThemePlaying.source, false));
        }
        else
        {
            StartCoroutine(FadeIn(_overlapThemeList[_overlapThemeList.Count - 1]));
            StartCoroutine(FadeOut(_overlapThemeList[_overlapThemeList.Count - 2].source, false));
        }
    }

    public void RemoveOverlapTheme(SoundAudioClip sound)
    {
        MusicTheme source = FindThemeByClip(sound.clip);
        if (source.source == null)
            return;

        //StopAllCoroutines();

        if (source.source.isPlaying)
        {
            if (_overlapThemeList.Count >= 2)
            {
                StartCoroutine(FadeIn(_overlapThemeList[_overlapThemeList.Count - 2]));
                StartCoroutine(FadeOut(source.source, true));
            }
            else
            {
                StartCoroutine(FadeIn(_levelThemePlaying));
                StartCoroutine(FadeOut(source.source, true));
            }

            _overlapThemeList.Remove(source);
        }
        else
        {
            _overlapThemeList.Remove(source);
            Destroy(source.source.gameObject);
        }
    }

    private MusicTheme FindThemeByClip(AudioClip clip)
    {
        foreach(MusicTheme theme in _overlapThemeList)
        {
            if (theme.source.clip == clip)
            {
                return theme;
            }
        }

        Debug.Log("No Source found!");
        return default;
    }

    private IEnumerator FadeIn(MusicTheme source)
    {
        if (!source.source.isPlaying)
            source.source.UnPause();

        float initialVolume = source.volume;
        float time = 0;
        while (time <= _fadeTime)
        {
            source.source.volume = Mathf.Lerp(0f, initialVolume, time / _fadeTime);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator FadeOut(AudioSource source, bool destroyFaded)
    {
        float initialVolume = source.volume;
        float time = 0;
        while (time <= _fadeTime)
        {
            source.volume = Mathf.Lerp(initialVolume, 0f, time / _fadeTime);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        source.Pause();

        if (destroyFaded)
        {
            Destroy(source.gameObject);
        }
    }
}
