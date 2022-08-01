public class MediumSanityState : PlayerSanityState {
    public override void OnStateEnter(PlayerDrivenCharacter character) => character.VFXHandler.SanityFX.SetVignette(.3f);

    public override void OnStateExit(PlayerDrivenCharacter character) {
        //throw new System.NotImplementedException();
    }
}
