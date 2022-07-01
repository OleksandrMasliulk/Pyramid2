using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Interractible Soundboard", menuName = "Soundboard/New Interractible Soundboard")]
public class InterractibleSoundBoardSO : SoundBoardSO
{
    [SerializeField] private InterractibleSoundBoard _soundBoard;
    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
