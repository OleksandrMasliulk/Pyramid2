[System.Serializable]
public class PlayerSoundBoard : SoundBoard {
    public SoundAudioClip walk;
    public SoundAudioClip die;

    public override void Init() {
        walk.Init();
        die.Init();
    }
}
