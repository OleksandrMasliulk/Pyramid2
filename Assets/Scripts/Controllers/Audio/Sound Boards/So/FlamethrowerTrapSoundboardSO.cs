using UnityEngine;

[CreateAssetMenu(fileName = "New Flamethrower trap Soundboard", menuName = "Soundboard/New Flamethrower trap Soundboard")]
public class FlamethrowerTrapSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _throwFlame;
    public SoundAudioClip ThrowFlameSound => _throwFlame;

    public override void Initialize(){
        _throwFlame.Init();
    }

    public override void Dispose(){
        _throwFlame.Dispose();
    }
}
