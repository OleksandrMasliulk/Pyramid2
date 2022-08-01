public class MummyStunnedState : MummyPhysicalState {
    private float _stunDuration;

    private MummyPhysicalStateMachine _stateMachine;

    public override void OnStateEnter(Mummy mummy) {
        mummy.MovementHandler.CanMove = false;
        mummy.AnimationHandler.SetStunned(true);
        Stun();
    }

    public MummyStunnedState(float stunDuration, MummyPhysicalStateMachine machine) {
        _stunDuration = stunDuration;
        _stateMachine = machine;
    }

    private async void Stun() {
        await System.Threading.Tasks.Task.Delay((int)_stunDuration * 1000);
        _stateMachine.SetState(_stateMachine.NormalState);
    }

    public override void OnStateExit(Mummy mummy) => mummy.AnimationHandler.SetStunned(false);
}