using UnityEngine;

[CreateAssetMenu(fileName = "New UI Soundboard", menuName = "Soundboard/New UI Soundboard")]
public class ButtonSoundBoardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _buttonOverlap;
    public SoundAudioClip ButtonOverlapSound => _buttonOverlap;
    [SerializeField] private SoundAudioClip _buttonClick;
    public SoundAudioClip ButtonClickSound => _buttonClick;

    public override void Initialize() {
        _buttonClick.Init();
        _buttonOverlap.Init();
    }

    public override void Dispose() {
        _buttonClick.Dispose();
        _buttonOverlap.Dispose();
    }

}
