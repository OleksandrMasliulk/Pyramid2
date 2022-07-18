using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        //player.Stats.IsGhost = true;
        //player.GraphicsController.SetGhostGraphics();
        //player.GhostCamera.gameObject.SetActive(true);
        //player.SetPlayerLayer(11);
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
    }
}
