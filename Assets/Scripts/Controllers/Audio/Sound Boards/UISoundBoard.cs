using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UISoundBoard : SoundBoard
{
    public SoundAudioClip buttonOverlap;
    public SoundAudioClip buttonClick;

    public override void Init()
    {
        buttonOverlap.Init();
        buttonClick.Init();
    }
}
