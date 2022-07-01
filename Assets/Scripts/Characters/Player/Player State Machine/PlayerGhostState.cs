using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.Stats.IsGhost = true;
        player.GraphicsController.SetGhostGraphics();
        player.GhostCamera.gameObject.SetActive(true);
        player.SetPlayerLayer(11);
    }

    public override void OnStateExit(PlayerController player)
    {
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
        if (direction.magnitude > 0f)
            player.MovementController.Move(direction); 
    }

    public override void OnInterractInput(PlayerController player)
    {
        player.InterractionController.Interract();
    }

    public override void OnInventoryUsePressInput(PlayerController player)
    {
    }

    public override void OnInventoryUseReleaseInput(PlayerController player)
    {
    }

    public override void OnInventoryDropInput(PlayerController player)
    {
    }
}
