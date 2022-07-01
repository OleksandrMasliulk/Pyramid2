using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public override void OnStateEnter(PlayerController player)
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<PlayerSoundBoard>().die);

        player.Stats.IsAlive = false;
        player.SanityController.UpdateSanity(100);
        player.GraphicsController.SetDie();
        player.HUDController.HideHUD();
        player.SetPlayerLayer(11);
        player.InventoryController.DropWholeInventory();
    }

    public override void OnStateExit(PlayerController player)
    {
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
