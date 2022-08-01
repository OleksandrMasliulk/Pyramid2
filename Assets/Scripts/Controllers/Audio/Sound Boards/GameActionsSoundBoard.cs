[System.Serializable]
public class GameActionsSoundBoard : SoundBoard {
    public SoundAudioClip playerLost;

    public override void Init() => playerLost.Init();
}
