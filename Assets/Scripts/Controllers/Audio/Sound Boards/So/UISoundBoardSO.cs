using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UI Soundboard", menuName = "Soundboard/New UI Soundboard")]
public class UISoundBoardSO : SoundBoardSO
{
    [SerializeField] private UISoundBoard _soundBoard;

    public override SoundBoard GetSoundBoard()
    {
        return _soundBoard;
    }
}
