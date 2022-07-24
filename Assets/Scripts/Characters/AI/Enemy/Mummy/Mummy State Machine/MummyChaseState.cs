using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyChaseState : MummyBehaviourState, ICanChase
{
    private MummyBehavoiuStateMachine _stateMachine;
    public float LineOfSightRadius { get; private set; }

    public float ChaseSpeed { get; private set; }

    public CharacterBase Target { get; private set; }

    public MummyChaseState(MummyStatsSO stats, CharacterBase target, MummyBehavoiuStateMachine machine)
    {
        this.LineOfSightRadius = stats.LineOfSightRadius;
        this.ChaseSpeed = stats.ChaseSpeed;
        Target = target;
        _stateMachine = machine;
    }

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Chase State");

        mummy.MovementHandler.SetSpeed(ChaseSpeed);
        mummy.MovementHandler.SetTarget(Target.transform);
        mummy.PlayerSeeker.OnLost += PlayerLost;
        Target.HealthHandler.OnCharacterDie += (character) => PlayerLost((PlayerDrivenCharacter)character);
    }

    private void PlayerLost(PlayerDrivenCharacter player)
    {
        _stateMachine.SetState(_stateMachine.RoamState);
    }

    public override void ExitState(Mummy mummy)
    {
        mummy.PlayerSeeker.OnLost -= PlayerLost;
        Target.HealthHandler.OnCharacterDie -= (character) => PlayerLost((PlayerDrivenCharacter)character);
    }

    public override void StateTick(Mummy mummy)
    {
        if (Target == null)
            return;

        float distance = Vector3.Distance(mummy.transform.position, Target.transform.position);

        if (distance <= mummy.Stats.AttackDistance)
        {
            _stateMachine.SetState(new MummyAttackState(mummy.Stats, Target.GetComponent<IDamageable>(), _stateMachine));
            return;
        }
    }
}
