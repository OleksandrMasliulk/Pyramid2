using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyStunnedState : MummyState
{
    private float timeToStunEnd;
    private MummyState lastState;
    private MummyExitStateArgs saveArgs;

    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        //Debug.LogWarning("Mummy entered Stunned State");

        //saveArgs = args;

        //mummy.MovementController.SetCanMove(false);
        //mummy.GraphicsController.SetStunned(true);

        //timeToStunEnd = mummy.Stats.StunDuration;
        //lastState = args.lastState;
    }

    public override void ExitState(Mummy mummy)
    {
        //mummy.MovementController.SetCanMove(true);
        //mummy.GraphicsController.SetStunned(false);
    }

    public override void StateTick(Mummy mummy)
    {
        //if (timeToStunEnd <= 0f)
        //{
        //    mummy.SetState(lastState, saveArgs);
        //}
        //else
        //{
        //    timeToStunEnd -= Time.deltaTime;
        //}
    }

    public override void OnTakeDamage(Mummy mummy)
    {
        //timeToStunEnd = mummy.Stats.StunDuration;
    }
}
