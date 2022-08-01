public class MummyBehavoiuStateMachine {
    public MummyRoamState RoamState;

    private Mummy _mummy;
    private MummyBehaviourState _currentState;

    public MummyBehavoiuStateMachine(Mummy mummy) {
        this._mummy = mummy;

        RoamState = new MummyRoamState(_mummy.Stats, this);
        SetState(RoamState);
        PlayerSanityHandler.OnLowSanity += (player) => { SetState(new MummySenseState(_mummy.Stats, player, this)); };
    }

    public void SetState(MummyBehaviourState state) {
        if (_currentState == state)
            return;

        _currentState?.ExitState(_mummy);
        _currentState = state;
        _currentState.EnterState(_mummy);
    }

    public void Tick() => _currentState.StateTick(_mummy);
}
