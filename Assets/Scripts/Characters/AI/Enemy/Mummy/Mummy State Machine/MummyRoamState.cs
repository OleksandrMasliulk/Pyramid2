using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class MummyRoamState : MummyBehaviourState, ICanRoam
{
    private MummyBehavoiuStateMachine _stateMachine;
    public float RoamRadius { get; private set; }
    
    public MummyRoamState(MummyStatsSO stats, MummyBehavoiuStateMachine machine)
    {
        this.RoamRadius = stats.RoamRadius;
        _stateMachine = machine;
    }

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Roam state");

        mummy.MovementHandler.SetSpeed(mummy.Stats.MovementSpeed);
        mummy.MovementHandler.SetTarget(GetRoamPosition(mummy));
        mummy.PlayerSeeker.OnSeeked += (player) => PlayerSeeked(player, mummy);
    }

    private void PlayerSeeked(PlayerDrivenCharacter player, Mummy mummy)
    {
        Debug.LogWarning("Seeked");
        MummyChaseState chase = new MummyChaseState(mummy.Stats, player, _stateMachine);
         _stateMachine.SetState(chase);
    }

    public override void ExitState(Mummy mummy)
    {
        mummy.PlayerSeeker.OnSeeked -= (player) => PlayerSeeked(player, mummy);
    }

    public override void StateTick(Mummy mummy)
    {
        if (mummy.MovementHandler.ReachedTarget)
            mummy.MovementHandler.SetTarget(GetRoamPosition(mummy));
    }

    public Vector3 GetRoamPosition(Mummy mummy)
    {
        Vector3 target = mummy.transform.position;

        PlayerDrivenCharacter pc = GetPlayer();
        if (pc != null)
            target = pc.transform.position;

        Vector3 pos = Helpers.GetRandomPositionInRadius(target, mummy.Stats.RoamRadius);

        while (!Map.Instance.IsPointWalkable(pos))
        {
            pos = Helpers.GetRandomPositionInRadius(target, mummy.Stats.RoamRadius);
        }

        return pos;
    }

    private PlayerDrivenCharacter GetPlayer()
    {
        if (GameController.Instance.AlivePlayersList.Count > 0)
        {
            int rand = Random.Range(0, GameController.Instance.AlivePlayersList.Count);
            PlayerDrivenCharacter pc = GameController.Instance.AlivePlayersList[rand];
            return pc;
        }

        return null;
    }
}
