public class PlayerPhysicalStateMachine {
    public PlayerAliveState AliveState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerGhostState GhostState { get; private set; }
    public PlayerCoveredState CoveredState { get; private set; }

    private PlayerDrivenCharacter _character;
    private PlayerPhysicalState _currentState;

    public PlayerPhysicalStateMachine(PlayerDrivenCharacter character) {
        _character = character;

        AliveState = new PlayerAliveState();
        DeadState = new PlayerDeadState();
        GhostState = new PlayerGhostState();
        CoveredState = new PlayerCoveredState();

        SetState(AliveState);
        _character.HealthHandler.OnCharacterDie += (character) => SetState(DeadState);
        IngameUIController.OnGhostClick += () => SetState(GhostState);
    }

    public void SetState(PlayerPhysicalState state) {
        if (_currentState == state)
            return;

        _currentState?.OnStateExit(_character);
        _currentState = state;
        _currentState.OnStateEnter(_character);
    }
}
