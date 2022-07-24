using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyBehavoiuStateMachine
{
    private Mummy _mummy;

    public MummyRoamState RoamState;
    private MummyBehaviourState _currentState;

    public MummyBehavoiuStateMachine(Mummy mummy)
    {
        this._mummy = mummy;

        RoamState = new MummyRoamState(_mummy.Stats, this);
        SetState(RoamState);

        foreach(PlayerDrivenCharacter p in GameController.Instance.AlivePlayersList)
        {
            p.SanityHandler.OnSanityChanged += (san) => { SanityChanged(p, san); };
        }
    }

    private void SanityChanged(PlayerDrivenCharacter p, int sanity)
    {
        if (sanity <= 25)
            SetState(new MummySenseState(_mummy.Stats, p, this));
    }

    public void SetState(MummyBehaviourState state)
    {
        if (_currentState == state)
            return;

        _currentState?.ExitState(_mummy);
        _currentState = state;
        _currentState.EnterState(_mummy);
    }

    public void Tick()
    {
        _currentState.StateTick(_mummy);
    }
}
