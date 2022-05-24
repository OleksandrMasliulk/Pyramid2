using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
        if (direction.magnitude > 0f)
        {
            player.GetPlayerMovementController().Move(direction);
            AudioManager.PlaySound(AudioManager.Sound.PlayerWalk, player.transform.position, .2f);
        }
        player.GetPlayerGraphicsController().SetMovementDirection(direction);
    }

    public override void OnInterractInput(PlayerController player)
    {
        player.GetPlayerInterractionController().Interract();
    }

    public override void OnInventoryUsePressInput(PlayerController player)
    {
        player.GetPlayerInventoryController().UseButtonPress();
    }

    public override void OnInventoryUseReleaseInput(PlayerController player)
    {
        player.GetPlayerInventoryController().UseButtonRelease();
    }

    public override void OnInventoryDropInput(PlayerController player)
    {
        player.GetPlayerInventoryController().Drop();
    }
}
