public class PlayerAliveState : PlayerPhysicalState {
    public override void OnStateEnter(PlayerDrivenCharacter player) {
        player.AnimationHandler.SetAliveAniationHandler();
        player.gameObject.ChangeTreeLayer(6);
        player.SanityHandler?.ModifySanity(100);
        player.CameraHandler.SetAlliveCamera();
        player.HUDHandler.HUD.SetActive(true);
        player.VFXHandler.DisableGhostParticles();
        player.VFXHandler.EnableStepParticles();
        player.VFXHandler.EnableAliveMaterial();
    }

    public override void OnStateExit(PlayerDrivenCharacter player) {
    }
}