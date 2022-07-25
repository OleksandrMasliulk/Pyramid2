using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player)
    {
        player.AnimationHandler.SetGhostAnimationHandler();
        player.CameraHandler.SetGhostCamera();
        player.gameObject.ChangeTreeLayer(9);
        player.VFXHandler.SpawnCorpse();
        player.VFXHandler.EnableGhostParticles();

        player.InventoryHandler.enabled = false;
        player.SanityHandler.enabled = false;
        player.HealthHandler.enabled = false;
    }

    public override void OnStateExit(PlayerDrivenCharacter player)
    {
        player.VFXHandler.DisableGhostParticles();

        player.InventoryHandler.enabled = true;
        player.SanityHandler.enabled = true;
        player.HealthHandler.enabled = true;
    }
}
