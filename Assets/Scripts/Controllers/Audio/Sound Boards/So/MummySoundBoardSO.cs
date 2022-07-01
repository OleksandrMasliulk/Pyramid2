using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mummy Soundboard", menuName = "Soundboard/New Mummy Soundboard")]
public class MummySoundBoardSO : SoundBoardSO
{
    [SerializeField] private MummySoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
