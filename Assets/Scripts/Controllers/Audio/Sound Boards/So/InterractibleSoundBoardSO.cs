using UnityEngine;

[CreateAssetMenu(fileName = "New Interractible Soundboard", menuName = "Soundboard/New Interractible Soundboard")]
public class InterractibleSoundBoardSO : SoundBoardSO {
    [SerializeField] private InterractibleSoundBoard _soundBoard;
    public override SoundBoard GetSoundBoard() => _soundBoard;
}
