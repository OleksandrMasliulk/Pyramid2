using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.GetPlayerParameters().SetIsGhost(true);
        player.GetPlayerGraphicsController().SetGhostGraphics();
        player.SetPlayerLayer(11);
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
        player.GetPlayerMovementController().Move(direction);
        player.GetPlayerGraphicsController().SetMovementDirection(direction);
    }

    public override void OnInterractInput(PlayerController player)
    {
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
