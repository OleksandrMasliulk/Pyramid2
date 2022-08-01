using UnityEngine;

public class MummyChaseState : MummyBehaviourState, ICanChase
{
    public float LineOfSightRadius { get; private set; }
    public float ChaseSpeed { get; private set; }
    public CharacterBase Target { get; private set; }

    private MummyBehavoiuStateMachine _stateMachine;

    public MummyChaseState(MummyStatsSO stats, CharacterBase target, MummyBehavoiuStateMachine machine) {
        LineOfSightRadius = stats.LineOfSightRadius;
        ChaseSpeed = stats.ChaseSpeed;
        Target = target;
        _stateMachine = machine;
    }

    public override void EnterState(Mummy mummy) {
        Debug.LogWarning("Mummy entered Chase State");

        mummy.MovementHandler.SetSpeed(ChaseSpeed);
        mummy.MovementHandler.SetTarget(Target.transform);
        mummy.PlayerSeeker.OnLost += (character) => PlayerLost((PlayerDrivenCharacter)character, mummy);
        Target.HealthHandler.OnCharacterDie += (character) => PlayerLost((PlayerDrivenCharacter)character, mummy);
    }

    private void PlayerLost(PlayerDrivenCharacter player, Mummy mummy) => _stateMachine.SetState(new MummyBreakLOSState(mummy.Stats, Target.transform.position, _stateMachine));

    public override void ExitState(Mummy mummy) {
        mummy.PlayerSeeker.OnLost -= (character) => PlayerLost((PlayerDrivenCharacter)character, mummy);
        Target.HealthHandler.OnCharacterDie -= (character) => PlayerLost((PlayerDrivenCharacter)character, mummy);
    }

    public override void StateTick(Mummy mummy) {
        if (Target == null)
            return;

        float distance = Vector3.Distance(mummy.transform.position, Target.transform.position);
        if (distance <= mummy.Stats.AttackDistance) {
            _stateMachine.SetState(new MummyAttackState(mummy.Stats, Target.GetComponent<IDamageable>(), _stateMachine));
            return;
        }
    }
}
