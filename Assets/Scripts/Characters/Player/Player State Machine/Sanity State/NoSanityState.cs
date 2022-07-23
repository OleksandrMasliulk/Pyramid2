public class NoSanityState : PlayerSanityState
{
    public override void OnStateEnter(PlayerDrivenCharacter character)
    {
        character.VFXHandler.SanityFX.SetVignette(.4f);
    }

    public override void OnStateExit(PlayerDrivenCharacter character)
    {
        //throw new System.NotImplementedException();
    }
}
