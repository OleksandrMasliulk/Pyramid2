using UnityEngine;

[CreateAssetMenu(fileName = "New Mummy Soundboard", menuName = "Soundboard/New Mummy Soundboard")]
public class MummySoundBoardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _walk;
    public SoundAudioClip WalkSound => _walk;

    public override void Initialize() => _walk.Init();

    public override void Dispose() => _walk.Dispose();
}
