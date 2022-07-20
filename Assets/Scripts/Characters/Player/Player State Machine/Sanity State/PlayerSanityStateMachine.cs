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
    public NoSanityState NoSanity { get; private set; }

    private PlayerSanityState _currentState;

    public PlayerSanityStateMachine(PlayerDrivenCharacter character)
    {
        this._character = character;

        FullSanity = new FullSanityState();
        HighSanity = new HighSanityState();
        MediumSanity = new MediumSanityState();
        LowSanity = new LowSanityState();
        NoSanity = new NoSanityState();

        _character.SanityHandler.OnSanityChanged += SanityChanged;

        SetState(FullSanity);
    }

    private void SanityChanged(int value)
    {
        switch (value)
        {
            case 100:
                SetState(FullSanity);
                break;
            case > 75 and < 100:
                SetState(HighSanity);
                break;
            case > 50 and <= 75:
                SetState(MediumSanity);
                break;
            case > 25 and <= 50:
                SetState(LowSanity);
                break;
            case <= 25:
                SetState(NoSanity);
                break;
        }
    }

    public void SetState(PlayerSanityState state)
    {
        if (_currentState == state)
            return;

        _currentState?.OnStateExit(_character);
        _currentState = state;
        _currentState.OnStateEnter(_character);
    }
}
