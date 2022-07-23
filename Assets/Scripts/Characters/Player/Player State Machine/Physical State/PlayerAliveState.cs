using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        player.AnimationHandler.SetAliveAniationHandler();
        player.gameObject.ChangeTreeLayer(6);
        player.SanityHandler.ModifySanity(100);
        player.CameraHandler.SetAlliveCamera();
        player.HUDHandler.HUD.SetActive(true);
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
    }
}
