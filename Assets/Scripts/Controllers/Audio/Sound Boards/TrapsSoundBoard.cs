using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrapsSoundBoard : SoundBoard
{
    public SoundAudioClip flamethrowerTrap;
    public SoundAudioClip arrowTrapShoot;
    public SoundAudioClip arrowTrapHitWall;
    public SoundAudioClip arrowTrapHitCharacter;
    public SoundAudioClip spikeTrapTrigger;
    public SoundAudioClip spikeTrapHide;

    public override void Init()
    {
        flamethrowerTrap.Init();
        arrowTrapShoot.Init();
        arrowTrapHitWall.Init();
        arrowTrapHitCharacter.Init();
        spikeTrapTrigger.Init();
        spikeTrapHide.Init();
    }
}
