public class PlayerCoveredState : PlayerPhysicalState
{
    public override void OnStateEnter(PlayerDrivenCharacter player) {
        //player.SetPlayerLayer(10);
        //player.Stats.IsCovered = true;
        //player.GraphicsController.DisableRenderer();
        //player.MovementController.enabled = false;
    }

    public override void OnStateExit(PlayerDrivenCharacter player) {
        //player.SetPlayerLayer(6);
        //player.Stats.IsCovered = false;
        //player.GraphicsController.EnableRenderer();
        //player.MovementController.enabled = true;
    }
}
