using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.Stats.IsAlive = true;
        player.GraphicsController.SetAliveGraphics();
        player.SetPlayerLayer(6);
        player.GhostCamera.gameObject.SetActive(false);
        player.HUDController.ShowHUD();
    }

    public override void OnStateExit(PlayerController player)
    {
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
        if (direction.magnitude > 0f)
        {
            player.MovementController.Move(direction);
        }
        else
        {
            player.GraphicsController.SetMovementDirection(Vector2.zero);
        }
    }

    public override void OnInterractInput(PlayerController player)
    {
        player.InterractionController.Interract();
    }

    public override void OnInventoryUsePressInput(PlayerController player)
    {
        player.InventoryController.UseButtonPress();
    }

    public override void OnInventoryUseReleaseInput(PlayerController player)
    {
        player.InventoryController.UseButtonRelease();
    }

    public override void OnInventoryDropInput(PlayerController player)
    {
        player.InventoryController.Drop();
    }
}
