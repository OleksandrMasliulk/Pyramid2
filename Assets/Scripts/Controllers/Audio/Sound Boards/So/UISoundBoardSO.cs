using UnityEngine;

[CreateAssetMenu(fileName = "New UI Soundboard", menuName = "Soundboard/New UI Soundboard")]
public class UISoundBoardSO : SoundBoardSO {
    [SerializeField] private UISoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard() => _soundBoard;
}
