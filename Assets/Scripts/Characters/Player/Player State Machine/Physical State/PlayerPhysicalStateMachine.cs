using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicalStateMachine
{
    private PlayerDrivenCharacter _character;

    public PlayerAliveState AliveState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerGhostState GhostState { get; private set; }
    public PlayerCoveredState CoveredState { get; private set; }

    private PlayerPhysicalState _currentState;

    public PlayerPhysicalStateMachine(PlayerDrivenCharacter character)
    {
        this._character = character;

        AliveState = new PlayerAliveState();
        DeadState = new PlayerDeadState();
        GhostState = new PlayerGhostState();
        CoveredState = new PlayerCoveredState();

        SetState(AliveState);
        _character.HealthHandler.OnCharacterDie += (character) => SetDeadState();
    }

    public void SetState(PlayerPhysicalState state)
    {
        _currentState?.OnStateExit(_character);
        _currentState = state;
        _currentState.OnStateEnter(_character);
    }

    private void SetDeadState()
    {
        SetState(DeadState);
    }
}
