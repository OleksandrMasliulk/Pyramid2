using UnityEngine;

[CreateAssetMenu(fileName = "New Items Soundboard", menuName = "Soundboard/New Items Soundboard")]
public class ItemsSoundBoardSO : SoundBoardSO {
    [SerializeField] private ItemsSoundboard _soundBoard;
    public override SoundBoard GetSoundBoard() => _soundBoard;
}
