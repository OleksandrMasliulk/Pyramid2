public class MummyPhysicalStateMachine {
    public MummyStunnedState StunnedState { get; private set; }
    public MummyNormalState NormalState { get; private set; }

    private MummyPhysicalState _currentState;
    private Mummy _mummy;

    public MummyPhysicalStateMachine(Mummy mummy) {
        _mummy = mummy;
        StunnedState = new MummyStunnedState(mummy.Stats.StunDuration, this);
        NormalState = new MummyNormalState();

        _mummy.HealthHandler.OnTakeDamage += OnDamageTaken;
    }

    private void OnDamageTaken() => SetState(StunnedState);

    public void SetState(MummyPhysicalState state) {
        if (state == _currentState)
            return;

        _currentState?.OnStateExit(_mummy);
        _currentState = state;
        _currentState.OnStateEnter(_mummy);
    }
}
