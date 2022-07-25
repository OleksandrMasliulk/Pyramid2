using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyStunnedState : MummyPhysicalState
{
    private MummyPhysicalStateMachine _stateMachine;
    private float _stunDuration;

    public override void OnStateEnter(Mummy mummy)
    {
        mummy.MovementHandler.CanMove = false;
        mummy.AnimationHandler.SetStunned(true);
        Stun();
    }

    public MummyStunnedState(float stunDuration, MummyPhysicalStateMachine machine)
    {
        _stunDuration = stunDuration;
        _stateMachine = machine;
    }

    private async void Stun()
    {
        await System.Threading.Tasks.Task.Delay((int)_stunDuration * 1000);
        _stateMachine.SetState(_stateMachine.NormalState);
    }

    public override void OnStateExit(Mummy mummy)
    {
        mummy.AnimationHandler.SetStunned(false);
    }
}
