using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyAttackState : MummyState
{
    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Attack state");
        args.playerSeeked.GetComponent<IDamageable>().TakeDamage(1);
        mummy.SetState(mummy.patrolState, null);
    }

    public override void ExitState(Mummy mummy)
    {

    }

    public override void StateTick(Mummy mummy)
    {

    }

    public override void OnTakeDamage(Mummy mummy)
    {

    }
}
