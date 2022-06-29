using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MummySoundBoard : SoundBoard
{
    public SoundAudioClip walk;

    public override void Init()
    {
        walk.Init();
    }
}
