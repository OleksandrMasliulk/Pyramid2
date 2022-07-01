using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Soundboard", menuName = "Soundboard/New Player Soundboard")]
public class PlayerSoundBoardSO : SoundBoardSO
{
    [SerializeField] private PlayerSoundBoard _soundBoard;
    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
