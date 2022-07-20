using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<PlayerSoundBoard>().die);

        player.SanityHandler.ModifySanity(100);
        player.AnimationHandler.SetDie();
        player.HUDHandler.HUD.SetActive(false);
        player.gameObject.ChangeTreeLayer(11);
        //player.InventoryController.DropWholeInventory();

        player.MovementHandler.enabled = false;
        player.SanityHandler.enabled = false;
        player.InventoryHandler.enabled = false;
        player.InterractionHandler.enabled = false;
        player.HealthHandler.enabled = false;
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
        player.MovementHandler.enabled = true;
        player.SanityHandler.enabled = true;
        player.InventoryHandler.enabled = true;
        player.InterractionHandler.enabled = true;
        player.HealthHandler.enabled = true;
    }
}
