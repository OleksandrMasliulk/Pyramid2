using UnityEngine;

[CreateAssetMenu(fileName = "New Lever Soundboard", menuName = "Soundboard/New Lever Soundboard")]
public class LeverSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _lever;
    public SoundAudioClip LeverSwitchSound => _lever;

    public override void Initialize() => _lever.Init();

    public override void Dispose() => _lever.Dispose();
}
