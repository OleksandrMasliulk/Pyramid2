using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InterractibleSoundBoard : SoundBoard
{
    public SoundAudioClip doorOpen;
    public SoundAudioClip doorClose;
    public SoundAudioClip lever;

    public override void Init()
    {
        doorOpen.Init();
        doorClose.Init();
    }
}
