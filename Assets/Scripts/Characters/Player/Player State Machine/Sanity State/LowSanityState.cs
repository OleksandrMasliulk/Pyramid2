using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowSanityState : PlayerSanityState
{
    public override void OnStateEnter(PlayerDrivenCharacter character)
    {
        character.VFXHandler.SanityFX.SetVignette(.3f);
    }

    public override void OnStateExit(PlayerDrivenCharacter character)
    {
        //throw new System.NotImplementedException();
    }
}
