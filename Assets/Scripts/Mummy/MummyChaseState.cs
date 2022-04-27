using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyChaseState : MummyState
{
    private Transform player;

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Chase State");
        player = PlayerController.Instance.transform;
        mummy.GetMovementController().SetSpeed(mummy.GetParameters().chaseMoveSpeed);
        mummy.GetMovementController().SetTarget(player);
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
        else if (distance > mummy.GetParameters().losRadius)
        {
            mummy.SetState(mummy.patrolState);
            return;
        }
    }
}
