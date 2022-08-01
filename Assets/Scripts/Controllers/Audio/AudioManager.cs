using UnityEngine;
using UnityEngine.Audio;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }

    [SerializeField] private SoundBoardSO[] _soundBoards;
    [SerializeField] private float _fadeTime;
    [SerializeField] private AudioMixerGroup _musicOutput;
    [SerializeField] private AudioMixerGroup _soundOutput;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
        InitSoundBoards();
    }

    private void InitSoundBoards() {
        foreach (SoundBoardSO sb in _soundBoards)
            sb.SoundBoard.Init();
    }

    public T GetSoundBoard<T>() where T : SoundBoard {
        T tmp = new SoundBoard() as T;
        foreach (SoundBoardSO sb in _soundBoards) {
            if (typeof(T) == sb.SoundBoard.GetType())
                return (T)sb.SoundBoard;
        }

        return null;
    }

    public async void PlaySound(SoundAudioClip sound) {
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

    public async void PlaySound(SoundAudioClip sound, bool looped) {
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

    public async void PlayeSound3D(SoundAudioClip sound, Vector3 position) {
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
        Destroy(go);
        sound.clip.ReleaseAsset();
    }

    public async void PlaySound(SoundAudioClip sound, float playbackTime) {
        AudioClip clip = await sound.clip.LoadAssetAsyncSafe<AudioClip>();
        if (clip == null || !sound.CanPlay())
            return;

        GameObject go = new GameObject("Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sound.type == SoundAudioClip.SoundType.Sound ? _soundOutput : _musicOutput;
        audioSource.volume = sound.volume;
        audioSource.PlayOneShot(clip);

        await Task.Delay((int)(playbackTime * 1000));
        Destroy(go);
        sound.clip.ReleaseAsset();
    }
    
    public async void PlayerSound3D(SoundAudioClip sound, Vector3 position, float playbackTime) {
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
        Destroy(go);
        sound.clip.ReleaseAsset();
    }

    private async Task<AudioSource> PlayMusicLooped(SoundAudioClip sound) {
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
}