using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameActionsSoundBoard : SoundBoard
{
    public SoundAudioClip playerLost;

    public override void Init()
    {
        playerLost.Init();
    }
}
