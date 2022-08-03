using UnityEngine;

[CreateAssetMenu(fileName = "New Spike trap Soundboard", menuName = "Soundboard/New Spike trap Soundboard")]
public class SpikeTrapSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _trigger;
    [SerializeField] private SoundAudioClip _hide;

    public override void Initialize(){
        _trigger.Init();
        _hide.Init();
    }

    public override void Dispose(){
        _trigger.Dispose();
        _hide.Dispose();
    }
}
