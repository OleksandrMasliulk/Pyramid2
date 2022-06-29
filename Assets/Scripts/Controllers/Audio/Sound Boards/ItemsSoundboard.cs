using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsSoundboard : SoundBoard
{
    public SoundAudioClip pickUp;
    public SoundAudioClip pickUpTreasure;

    public override void Init()
    {
        pickUp.Init();
        pickUpTreasure.Init();
    }
}
