using UnityEngine;

[CreateAssetMenu(fileName = "New Music Soundboard", menuName = "Soundboard/New Music Soundboard")]
public class MusicSoundBoardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _mainMenuTheme;
    public SoundAudioClip MainMenuTheme => _mainMenuTheme;
    [SerializeField] private SoundAudioClip _pyramidTheme;
    public SoundAudioClip PyramidTheme => _pyramidTheme;
    [SerializeField] private SoundAudioClip _lowSanitySFX;
    public SoundAudioClip LowSanitySFX => _lowSanitySFX;
    [SerializeField] private SoundAudioClip _noSanitySFX;
    public SoundAudioClip NoSanitySFX => _noSanitySFX;
    

    public override void Initialize() {   
        _mainMenuTheme.Init();
        _pyramidTheme.Init();
        _lowSanitySFX.Init();
        _noSanitySFX.Init();
    }

    public override void Dispose() {
        _mainMenuTheme.Dispose();
        _pyramidTheme.Dispose();
        _lowSanitySFX.Dispose();
        _noSanitySFX.Dispose();
    }
}
