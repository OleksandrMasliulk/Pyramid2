using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundBoardSO : ScriptableObject
{
    public SoundBoard SoundBoard => GetSoundBoard();

    public abstract SoundBoard GetSoundBoard();
}
