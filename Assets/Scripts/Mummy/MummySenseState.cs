using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySenseState : MummyState
{
    private PlayerController player;
    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Sense State");
        player = PlayerController.Instance;

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
            mummy.SetState(mummy.attackState);
            return;
        }

        if (player.GetPlayerSanityController().GetSanity() > 25)
        {
            mummy.SetState(mummy.patrolState);
            return;
        }
    }
}
