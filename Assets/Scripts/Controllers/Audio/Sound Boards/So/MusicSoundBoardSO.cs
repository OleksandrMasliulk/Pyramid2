using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music Soundboard", menuName = "Soundboard/New Music Soundboard")]
public class MusicSoundBoardSO : SoundBoardSO
{
    [SerializeField] private MusicSoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
