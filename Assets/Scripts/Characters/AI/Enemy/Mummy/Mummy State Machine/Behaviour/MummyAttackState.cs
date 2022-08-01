using UnityEngine;

public class MummyAttackState : MummyBehaviourState, ICanAttack {
    public float AttackRange { get; private set; }

    private MummyBehavoiuStateMachine _stateMachine;
    private IDamageable _target;

    public MummyAttackState(MummyStatsSO stats, IDamageable target, MummyBehavoiuStateMachine machine) {
        AttackRange = stats.AttackDistance;
        _target = target;
        _stateMachine = machine;
    }

    public void Attack(IDamageable target) => target.TakeDamage(1);

    public override void EnterState(Mummy mummy) {
        Debug.LogWarning("Mummy entered Attack state");
        Attack(_target);
        _stateMachine.SetState(_stateMachine.RoamState);
    }

    public override void ExitState(Mummy mummy) => Debug.Log("Exit attack state");

    public override void StateTick(Mummy mummy) {
        // (Vector3.Distance(mummy.transform.position, _target.))
    }
}
