using UnityEngine;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class SoundAudioClip : IDisposable {
    public enum SoundType  {
        Sound,
        Music
    }

    [Header("General parameters")]
    public SoundType type;
    public AssetReference clip;
    [Range(0f, 1f)]
    public float volume;
    public float repeatPlayeDelay;
    private float _lastTimePlayed;

    [Header("3D Sound settings")]
    [Range(1f, 100f)]
    public float maxRange;

    public void Init() => _lastTimePlayed = Time.time;

    public bool CanPlay() {
        if (repeatPlayeDelay == 0)
            return true;

        if (_lastTimePlayed + repeatPlayeDelay < Time.time) {
            _lastTimePlayed = Time.time;
            return true;
        }
        else
            return false;
    }

    public void Dispose() {
        clip.ReleaseAssetSafe();
    }
}
