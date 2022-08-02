[System.Serializable]
public class ItemsSoundboard : SoundBoard {
    public SoundAudioClip pickUp;
    public SoundAudioClip pickUpTreasure;

    public override void Init() {
        pickUp.Init();
        pickUpTreasure.Init();
    }
}
