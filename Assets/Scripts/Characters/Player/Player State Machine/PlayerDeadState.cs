using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        player.GetPlayerParameters().SetIsAlive(false);
        player.GetPlayerGraphicsController().SetDie();
        player.GetPlayerHUDContorller().HideHUD();
        player.SetPlayerLayer(11);
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
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