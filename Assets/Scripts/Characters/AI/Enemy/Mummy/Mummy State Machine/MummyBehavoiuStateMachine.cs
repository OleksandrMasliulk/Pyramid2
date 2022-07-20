using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyBehavoiuStateMachine
{
    private Mummy _mummy;

    public MummyAttackState AttackState;
    public MummyRoamState RoamState;
    public MummySenseState SenseState;
    public MummyBreakLOSState BreakLOSState;
    private MummyBehaviourState _currentState;

    public MummyBehavoiuStateMachine(Mummy mummy)
    {
        this._mummy = mummy;

        RoamState = new MummyRoamState(_mummy.Stats, this);
        SetState(RoamState);
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
