using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoveredState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.SetPlayerLayer(10);
        player.Stats.IsCovered = true;
        player.GraphicsController.DisableRenderer();
        player.MovementController.enabled = false;
    }

    public override void OnStateExit(PlayerController player)
    {
        player.SetPlayerLayer(6);
        player.Stats.IsCovered = false;
        player.GraphicsController.EnableRenderer();
        player.MovementController.enabled = true;
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
    }

    public override void OnInterractInput(PlayerController player)
    {
        player.CoverController.Cover.Interract(player);
        //player.InterractionController.Interract();
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
