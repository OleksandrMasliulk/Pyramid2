using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class AudioManager : MonoBehaviour
{
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

    [SerializeField] private AudioMixerGroup _musicOutput;
    [SerializeField] private AudioMixerGroup _soundOutput;

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

    public async void PlaySound(SoundAudioClip sound)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.volume = sound.volume;
        audioSource.PlayOneShot(clip);

        float duration = clip.length;
        await Task.Delay((int)(duration * 1000));
        Addressables.ReleaseInstance(go);
        sound.clip.ReleaseAsset();
    }

    public async void PlaySound(SoundAudioClip sound, bool looped)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.clip = clip;
        audioSource.loop = looped;
        audioSource.volume = sound.volume;
        audioSource.Play();
    }

    public async void PlayeSound3D(SoundAudioClip sound, Vector3 position)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        go.transform.position = position;
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.clip = clip;
        audioSource.volume = sound.volume;
        audioSource.spatialBlend = 1;
        audioSource.minDistance = .05f;
        audioSource.maxDistance = sound.maxRange;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.Play();

        float duration = clip.length;
        await Task.Delay((int)(duration * 1000));
        Addressables.ReleaseInstance(go);
        sound.clip.ReleaseAsset();

    }
    public async void PlaySound(SoundAudioClip sound, float playbackTime)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.volume = sound.volume;
        audioSource.PlayOneShot(clip);

        await Task.Delay((int)(playbackTime * 1000));
        Addressables.ReleaseInstance(go);
        sound.clip.ReleaseAsset();
    }
    
    public async void PlayerSound3D(SoundAudioClip sound, Vector3 position, float playbackTime)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        go.transform.position = position;
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.clip = clip;
        audioSource.volume = sound.volume;
        audioSource.spatialBlend = 1;
        audioSource.minDistance = .05f;
        audioSource.maxDistance = sound.maxRange;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.Play();

        await Task.Delay((int)(playbackTime * 1000));
        Addressables.ReleaseInstance(go);
        sound.clip.ReleaseAsset();
    }

    private async Task<AudioSource> PlayMusicLooped(SoundAudioClip sound)
    {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();

        if (clip == null || !sound.CanPlay())
            return null;

        GameObject go = new GameObject("Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = sound.volume;
        audioSource.Play();

        return audioSource;
    }

    public async void PlayLevelTheme(SoundAudioClip sound)
    {
        //StopAllCoroutines();

        if (_levelThemePlaying.source == null)
        {
            _levelThemePlaying = new MusicTheme(await PlayMusicLooped(sound), sound.volume);
            StartCoroutine(FadeIn(_levelThemePlaying));
        }
        else
        {
            AudioSource oldTheme = _levelThemePlaying.source;
            _levelThemePlaying = new MusicTheme(await PlayMusicLooped(sound), sound.volume);
            StartCoroutine(FadeOut(oldTheme, true));
            StartCoroutine(FadeIn(_levelThemePlaying));
        }

    }

    public async void PlayOverlapTheme(SoundAudioClip sound)
    {
        if (FindThemeByClip(await sound.clip.LoadAssetAsyncSafe<AudioClip>()).source != null)
            return;

        //StopAllCoroutines();

        _overlapThemeList.Add(new MusicTheme(await PlayMusicLooped(sound), sound.volume));
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

    public async void RemoveOverlapTheme(SoundAudioClip sound)
    {
        MusicTheme source = FindThemeByClip(await sound.clip.LoadAssetAsyncSafe<AudioClip>());
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
        }
    }

    private MusicTheme FindThemeByClip(AudioClip clip)
    {
        if (_levelThemePlaying.source.clip == clip)
            return _levelThemePlaying;

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
            Addressables.Release<AudioClip>(source.clip);
            Addressables.ReleaseInstance(source.gameObject);
        }
    }
}
