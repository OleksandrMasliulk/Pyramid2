using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanityStateMachine : MonoBehaviour
{
    private PlayerDrivenCharacter _character;

    public FullSanityState FullSanity { get; private set; }
    public HighSanityState HighSanity { get; private set; }
    public MediumSanityState MediumSanity { get; private set; }
    public LowSanityState LowSanity { get; private set; }

    private PlayerSanityState _currentState;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
    }

    public void SetState(PlayerSanityState state)
    {
        _currentState.OnStateExit(_character);
        _currentState = state;
        _currentState.OnStateEnter(_character);
    }
}
