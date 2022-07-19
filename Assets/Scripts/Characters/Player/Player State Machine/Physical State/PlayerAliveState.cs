using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        player.AnimationHandler.SetAliveAniationHandler();
        player.gameObject.layer = 6;
        player.SanityHandler.ModifySanity(100);
        player.GhostCamera.gameObject.SetActive(false);
        player.HUDHandler.HUD.SetActive(true);
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
    }
}
