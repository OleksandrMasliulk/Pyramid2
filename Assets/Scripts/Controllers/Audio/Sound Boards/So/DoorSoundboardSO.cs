using UnityEngine;

[CreateAssetMenu(fileName = "New Door Soundboard", menuName = "Soundboard/New Door Soundboard")]
public class DoorSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _doorOpen;
    public SoundAudioClip DoorOpenSound => _doorOpen;
    [SerializeField] private SoundAudioClip _doorClose;
    public SoundAudioClip DoorCloseSound => _doorClose;

    public override void Initialize() {
        _doorOpen.Init();
        _doorClose.Init();
    }

    public override void Dispose() {
        _doorOpen.Dispose();
        _doorClose.Dispose();
    }
}
