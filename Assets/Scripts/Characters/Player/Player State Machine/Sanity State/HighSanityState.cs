public class HighSanityState : PlayerSanityState {
    public override void OnStateEnter(PlayerDrivenCharacter character) => character.VFXHandler.SanityFX.SetVignette(.2f);

    public override void OnStateExit(PlayerDrivenCharacter character) {
        //throw new System.NotImplementedException();
    }
}
