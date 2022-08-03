using UnityEngine;

[CreateAssetMenu(fileName = "New Arrow trap Soundboard", menuName = "Soundboard/New Arrow trap Soundboard")]
public class ArrowTrapSoundboardSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _shoot;
    public SoundAudioClip ShootSound => _shoot;
    [SerializeField] private SoundAudioClip _hitWall;
    public SoundAudioClip HitWallSound => _hitWall;
    [SerializeField] private SoundAudioClip _hitCharacter;
    public SoundAudioClip HitCharacterSound => _hitCharacter;

    public override void Initialize(){
        _shoot.Init();
        _hitWall.Init();
        _hitCharacter.Init();
    }

    public override void Dispose(){
        _shoot.Dispose();
        _hitWall.Dispose();
        _hitCharacter.Dispose();
    }
}
