using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySenseState : MummyState
{
    private PlayerController player;
    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Sense State");
        player = args.playerSeeked;

        mummy.GetMovementController().SetSpeed(mummy.GetParameters().senseMoveSpeed);
        mummy.GetMovementController().SetTarget(player.transform);
    }

    public override void ExitState(Mummy mummy)
    {
        player = null;
    }

    public override void StateTick(Mummy mummy)
    {
        float distance = Vector3.Distance(mummy.transform.position, player.transform.position);

        if (distance <= mummy.GetParameters().attackDistance)
        {
            mummy.SetState(mummy.attackState, new MummyExitStateArgs(player, player.transform.position, mummy.senseState));
            return;
        }

        if (player.GetPlayerSanityController().GetSanity() > 25)
        {
            mummy.SetState(mummy.patrolState, null);
            return;
        }
    }

    public override void OnTakeDamage(Mummy mummy)
    {
        mummy.SetState(mummy.stunnedState, new MummyExitStateArgs(player, player.transform.position, mummy.senseState));
    }
}
