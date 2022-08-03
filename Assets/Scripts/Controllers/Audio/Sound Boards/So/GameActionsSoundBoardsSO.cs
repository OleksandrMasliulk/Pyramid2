using UnityEngine;

[CreateAssetMenu(fileName = "New GameActions Soundboard", menuName = "Soundboard/New GameActions Soundboard")]
public class GameActionsSoundBoardsSO : SoundBoardSO {
    [SerializeField] private SoundAudioClip _playerLost;
    public SoundAudioClip PlayerLostSound => _playerLost;

    public override void Initialize(){
        _playerLost.Init();
    }

    public override void Dispose(){
        _playerLost.Dispose();
    }

}
