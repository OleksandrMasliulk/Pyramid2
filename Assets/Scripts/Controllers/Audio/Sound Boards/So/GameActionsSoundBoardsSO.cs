using UnityEngine;

[CreateAssetMenu(fileName = "New GameActions Soundboard", menuName = "Soundboard/New GameActions Soundboard")]
public class GameActionsSoundBoardsSO : SoundBoardSO {
    [SerializeField] private GameActionsSoundBoard _soundBoard;
    public override SoundBoard GetSoundBoard() => _soundBoard;
}
