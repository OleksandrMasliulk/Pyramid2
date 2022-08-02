using UnityEngine;

[CreateAssetMenu(fileName = "New Music Soundboard", menuName = "Soundboard/New Music Soundboard")]
public class MusicSoundBoardSO : SoundBoardSO {
    [SerializeField] private MusicSoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard() => _soundBoard;
}
