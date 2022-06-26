using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyChaseState : MummyState
{
    private PlayerController player;

    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Chase State");
        player = args.playerSeeked;

        mummy.MovementController.SetSpeed(mummy.Stats.ChaseMoveSpeed);
        mummy.MovementController.Move(player.transform.position);
    }

    public override void ExitState(Mummy mummy)
    {
        mummy.MovementController.CancelMoveTask();
        player = null;
    }

    public override void StateTick(Mummy mummy)
    {
        float distance = Vector3.Distance(mummy.transform.position, player.transform.position);

        if (distance <= mummy.Stats.AttackDistance)
        {
            mummy.SetState(mummy.attackState, new MummyExitStateArgs(player, player.transform.position, mummy.chaseState));
            return;
        }
        if (distance > mummy.Stats.LoSRadius || player.Stats.IsCovered)
        {
            mummy.SetState(mummy.breakLOSState, new MummyExitStateArgs(player, player.transform.position, mummy.chaseState));
            return;
        }
    }

    public override void OnTakeDamage(Mummy mummy)
    {
        mummy.SetState(mummy.stunnedState, new MummyExitStateArgs(player, player.transform.position, mummy.chaseState));
    }
}
