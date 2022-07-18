using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        //player.Stats.IsAlive = true;
        //player.GraphicsController.SetAliveGraphics();
        //player.SetPlayerLayer(6);
        //player.GhostCamera.gameObject.SetActive(false);
        //player.HUDController.ShowHUD();
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
    }
}
