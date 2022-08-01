[System.Serializable]
public class MummySoundBoard : SoundBoard {
    public SoundAudioClip walk;

    public override void Init() => walk.Init();
}
