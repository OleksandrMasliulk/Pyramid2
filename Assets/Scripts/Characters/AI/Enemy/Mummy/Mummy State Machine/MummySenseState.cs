using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySenseState : MummyBehaviourState, ICanSense
{
    private MummyBehavoiuStateMachine _stateMachine;

    public float SenseMoveSpeed { get; private set; }

    public CharacterBase Target { get; private set; }

    public MummySenseState(MummyStatsSO stats, CharacterBase target)
    {
        SenseMoveSpeed = stats.SenseMoveSpeed;
        Target = target;
    }

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Sense State");

        mummy.MovementHandler.SetSpeed(SenseMoveSpeed);
        mummy.MovementHandler.SetTarget(Target.transform);

        Target.GetComponent<IHaveSanity>().OnSanityChanged += SanityChangerd;
    }

    private void SanityChangerd(int value)
    {
        if (value > 25)
            _stateMachine.SetState(_stateMachine.RoamState);

    }

    public override void ExitState(Mummy mummy)
    {
        Target.GetComponent<IHaveSanity>().OnSanityChanged -= SanityChangerd;
    }

    public override void StateTick(Mummy mummy)
    {
        float distance = Vector3.Distance(mummy.transform.position, Target.transform.position);

        if (distance <= mummy.Stats.AttackDistance)
        {
            _stateMachine.SetState(_stateMachine.AttackState);
            return;
        }
    }
}
