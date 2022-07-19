using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanityStateMachine
{
    private PlayerDrivenCharacter _character;

    public FullSanityState FullSanity { get; private set; }
    public HighSanityState HighSanity { get; private set; }
    public MediumSanityState MediumSanity { get; private set; }
    public LowSanityState LowSanity { get; private set; }

    private PlayerSanityState _currentState;

    public PlayerSanityStateMachine(PlayerDrivenCharacter character)
    {
        this._character = character;
        SetState(FullSanity);
    }

    public void SetState(PlayerSanityState state)
    {
        _currentState?.OnStateExit(_character);
        _currentState = state;
        _currentState.OnStateEnter(_character);
    }
}
