using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<PlayerSoundBoard>().die);

        //player.Stats.IsAlive = false;
        //player.SanityController.UpdateSanity(100);
        //player.GraphicsController.SetDie();
        //player.HUDController.HideHUD();
        //player.SetPlayerLayer(11);
        //player.InventoryController.DropWholeInventory();
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
    }
}
