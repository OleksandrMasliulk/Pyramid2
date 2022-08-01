public class FullSanityState : PlayerSanityState {
    public override void OnStateEnter(PlayerDrivenCharacter character) => character.VFXHandler.SanityFX.SetVignette(0);

    public override void OnStateExit(PlayerDrivenCharacter character) {
        //throw new System.NotImplementedException();
    }
}
