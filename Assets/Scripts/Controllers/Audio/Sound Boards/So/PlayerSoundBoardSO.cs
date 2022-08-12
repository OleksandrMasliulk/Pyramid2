using UnityEngine;

[CreateAssetMenu(fileName = "New Player Soundboard", menuName = "Soundboard/New Player Soundboard")]
public class PlayerSoundBoardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _walk;
    public SoundAudioClip WalkSound => _walk;
    [SerializeField] private SoundAudioClip _die;
    public SoundAudioClip DieSound => _die;

    public override void Initialize(){
        _walk.Init();
        _die.Init();
    }

    public override void Dispose() {
        _walk.Dispose();
        _die.Dispose();
    }

}
