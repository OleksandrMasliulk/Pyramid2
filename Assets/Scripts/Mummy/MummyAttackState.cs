using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttackState : MummyState
{
    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Attack state");
        PlayerController.Instance.TakeDamage(1);
        mummy.SetState(mummy.patrolState);
    }

    public override void ExitState(Mummy mummy)
    {

    }

    public override void StateTick(Mummy mummy)
    {

    }
}
