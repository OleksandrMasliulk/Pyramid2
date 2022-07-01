using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Traps Soundboard", menuName = "Soundboard/New Traps Soundboard")]
public class TrapsSoundBoardSO : SoundBoardSO
{
    [SerializeField] private TrapsSoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
