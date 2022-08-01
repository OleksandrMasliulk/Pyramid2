using UnityEngine;

public class MummySenseState : MummyBehaviourState, ICanSense {
    public float SenseMoveSpeed { get; private set; }
    public CharacterBase Target { get; private set; }

    private MummyBehavoiuStateMachine _stateMachine;
    public MummySenseState(MummyStatsSO stats, CharacterBase target, MummyBehavoiuStateMachine machine) {
        SenseMoveSpeed = stats.SenseMoveSpeed;
        Target = target;
        _stateMachine = machine;
    }

    public override void EnterState(Mummy mummy) {
        Debug.LogWarning("Mummy entered Sense State");

        mummy.MovementHandler.SetSpeed(SenseMoveSpeed);
        mummy.MovementHandler.SetTarget(Target.transform);

        Target.GetComponent<IHaveSanity>().OnSanityChanged += (val) => { SanityChangerd(val, mummy); };
        Target.HealthHandler.OnCharacterDie += (character) => { CheckForAnother(mummy); };
    }

    private void SanityChangerd(int value, Mummy mummy) {
        if (value > 25)
            CheckForAnother(mummy);
    }

    private void CheckForAnother(Mummy mummy) {
        foreach (PlayerDrivenCharacter p in GameController.Instance.AlivePlayersList)
            if (p.SanityHandler.CurrentSanity <= 25) {
                _stateMachine.SetState(new MummySenseState(mummy.Stats, p, _stateMachine));
                return;
            }
        _stateMachine.SetState(_stateMachine.RoamState);
    }

    public override void ExitState(Mummy mummy) {
        Target.GetComponent<IHaveSanity>().OnSanityChanged -= (val) => { SanityChangerd(val, mummy); };
        Target.HealthHandler.OnCharacterDie -= (character) => { _stateMachine.SetState(_stateMachine.RoamState); };
    }

    public override void StateTick(Mummy mummy) {
        float distance = Vector3.Distance(mummy.transform.position, Target.transform.position);
        if (distance <= mummy.Stats.AttackDistance) {
            _stateMachine.SetState(new MummyAttackState(mummy.Stats, Target.GetComponent<IDamageable>(), _stateMachine));
            return;
        }
    }
}
