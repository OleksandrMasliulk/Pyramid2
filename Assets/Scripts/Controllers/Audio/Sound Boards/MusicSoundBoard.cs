[System.Serializable]
public class MusicSoundBoard : SoundBoard {
    public SoundAudioClip mainMenuTheme;
    public SoundAudioClip pyramidMenuTheme;
    public SoundAudioClip lowSanitySFX;
    public SoundAudioClip noSanitySFX;

    public override void Init() {
        mainMenuTheme.Init();
        pyramidMenuTheme.Init();
        lowSanitySFX.Init();
        noSanitySFX.Init();
    }
}
