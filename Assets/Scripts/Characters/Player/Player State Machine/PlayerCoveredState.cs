using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoveredState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
    }

    public override void OnDirectionInput(PlayerController player, Vector2 direction)
    {
    }

    public override void OnInterractInput(PlayerController player)
    {
        player.GetPlayerInterractionController().Interract();
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
