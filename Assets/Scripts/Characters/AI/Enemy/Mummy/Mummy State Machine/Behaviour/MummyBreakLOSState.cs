using UnityEngine;

public class MummyBreakLOSState : MummyBehaviourState, ICanRoam {
    public float RoamRadius { get; private set; }
    private MummyBehavoiuStateMachine _stateMachine;

    private Vector3 _pos;

    public MummyBreakLOSState(MummyStatsSO stats, Vector3 lastPos, MummyBehavoiuStateMachine machine) {
        RoamRadius = stats.RoamRadius;
        _pos = lastPos;
        _stateMachine = machine;
    }

    public override void EnterState(Mummy mummy) {
        Debug.LogWarning("Mummy entered Break LOS state");

        mummy.MovementHandler.SetSpeed(mummy.Stats.MovementSpeed);
        mummy.MovementHandler.SetTarget(GetRoamPosition(mummy));
        mummy.PlayerSeeker.OnSeeked += (player) => PlayerSeeked(player, mummy);
    }

    private void PlayerSeeked(PlayerDrivenCharacter player, Mummy mummy) {
        Debug.LogWarning("Seeked");
        MummyChaseState chase = new MummyChaseState(mummy.Stats, player, _stateMachine);
        _stateMachine.SetState(chase);
    }

    public override void ExitState(Mummy mummy) => mummy.PlayerSeeker.OnSeeked -= (player) => PlayerSeeked(player, mummy);

    public override void StateTick(Mummy mummy) {
        if (mummy.MovementHandler.ReachedTarget)
            mummy.MovementHandler.SetTarget(GetRoamPosition(mummy));
    }

    public Vector3 GetRoamPosition(Mummy mummy) {
        Vector3 pos = Helpers.GetRandomPositionInRadius2D(_pos, mummy.Stats.RoamRadius);

        while (!Map.Instance.IsPointWalkable(pos))
            pos = Helpers.GetRandomPositionInRadius2D(_pos, mummy.Stats.RoamRadius);

        return pos;
    }
}