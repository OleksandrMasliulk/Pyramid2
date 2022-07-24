using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyBreakLOSState : MummyBehaviourState, ICanRoam
{
    public float RoamRadius { get; private set; }

    private Vector3 _pos;

    public MummyBreakLOSState(MummyStatsSO stats, Vector3 lastPos)
    {
        RoamRadius = stats.RoamRadius;
        _pos = lastPos;
    }

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Break LOS state");

        //mummy.MovementController.SetSpeed(mummy.Stats.MoveSpeed);
        //lastSeenPosition = args.lastSeenPosition;
        ////Roam(mummy, lastSeenPosition);

        //mummy.MovementController.SetTarget(GetRoamPosition(mummy));

        //timeToNextSenseTick = mummy.Stats.SenseTickTime;
        //timeToRoamState = mummy.Stats.BreakLoSStateDuration;
    }

    public override void ExitState(Mummy mummy)
    {
        Debug.Log("Exit break los state");
    }

    public override void StateTick(Mummy mummy)
    {
        //if (mummy.MovementController.ReachedTarget)
        //{
        //    mummy.MovementController.SetTarget(GetRoamPosition(mummy));
        //}

        //if (timeToNextSenseTick <= 0f)
        //{
        //    PlayerController player = SensePlayer(mummy);
        //    if (player != null)
        //    {
        //        Debug.Log("Player seeked");
        //        mummy.SetState(mummy.chaseState, new MummyExitStateArgs(player, player.transform.position, mummy.breakLOSState));
        //        return;
        //    }
        //    timeToNextSenseTick = mummy.Stats.SenseTickTime;
        //}
        //else
        //{
        //    timeToNextSenseTick -= Time.deltaTime;
        //}

        //if (timeToRoamState <= 0f)
        //{
        //    mummy.SetState(mummy.roamState, null);
        //    return;
        //}
        //else
        //{
        //    timeToRoamState -= Time.deltaTime;
        //}
    }

    //public Vector3 GetRoamPosition(Mummy mummy)
    //{
    //    Vector3 target = lastSeenPosition;
    //    Vector3 pos = GetRandomPosition(target, mummy.Stats.BreakLoSRoamRadius);

    //    while (!Map.Instance.IsPointWalkable(pos))
    //    {
    //        pos = GetRandomPosition(target, mummy.Stats.BreakLoSRoamRadius);
    //    }

    //    return pos;
    //}

    //private Vector3 GetRandomPosition(Vector3 target, float range)
    //{
    //    Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    //    return target + randomDirection * range;
    //}

    //private PlayerController SensePlayer(Mummy mummy)
    //{
    //    PlayerController player = null;

    //    Collider2D col = Physics2D.OverlapCircle(mummy.transform.position, mummy.Stats.LoSRadius, mummy.Stats.SenseLayer);
    //    if (col != null)
    //    {
    //        player = col.GetComponent<PlayerController>();
    //    }

    //    return player;
    //}

    ////private async void Roam(Mummy mummy, Vector3 roamPos)
    ////{
    ////    await mummy.MovementController.Move(roamPos);

    ////    Roam(mummy, GetRandomPosition(lastSeenPosition, mummy.Stats.BreakLoSRoamRadius));
    ////}
}
