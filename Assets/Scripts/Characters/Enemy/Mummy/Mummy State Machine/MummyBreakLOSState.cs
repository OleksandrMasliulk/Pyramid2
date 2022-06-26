using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyBreakLOSState : MummyState
{
    private Transform destinationPoint;

    private Vector3 lastSeenPosition;

    private float timeToRoamState;
    private float timeToNextSenseTick;



    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Break LOS state");

        mummy.MovementController.SetSpeed(mummy.Stats.MoveSpeed);
        lastSeenPosition = args.lastSeenPosition;
        Roam(mummy, lastSeenPosition);

        timeToNextSenseTick = mummy.Stats.SenseTickTime;
        timeToRoamState = mummy.Stats.BreakLoSStateDuration;
    }

    public override void ExitState(Mummy mummy)
    {
        mummy.MovementController.CancelMoveTask();
    }

    public override void StateTick(Mummy mummy)
    {
        if (timeToNextSenseTick <= 0f)
        {
            PlayerController player = SensePlayer(mummy);
            if (player != null)
            {
                Debug.Log("Player seeked");
                mummy.SetState(mummy.chaseState, new MummyExitStateArgs(player, player.transform.position, mummy.breakLOSState));
                return;
            }
            timeToNextSenseTick = mummy.Stats.SenseTickTime;
        }
        else
        {
            timeToNextSenseTick -= Time.deltaTime;
        }

        if (timeToRoamState <= 0f)
        {
            mummy.SetState(mummy.roamState, null);
            return;
        }
        else
        {
            timeToRoamState -= Time.deltaTime;
        }
    }

    private Vector3 GetRandomPosition(Vector3 target, float range)
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        return target + randomDirection * range;
    }

    private void DestroyDestinationPoint(Mummy mummy, Transform destPoint)
    {
        MonoBehaviour.Destroy(destPoint.gameObject);
        destinationPoint = null;
    }

    private PlayerController SensePlayer(Mummy mummy)
    {
        PlayerController player = null;

        Collider2D col = Physics2D.OverlapCircle(mummy.transform.position, mummy.Stats.LoSRadius, mummy.Stats.SenseLayer);
        if (col != null)
        {
            player = col.GetComponent<PlayerController>();
        }

        return player;
    }

    private async void Roam(Mummy mummy, Vector3 roamPos)
    {
        await mummy.MovementController.Move(roamPos);

        Roam(mummy, GetRandomPosition(lastSeenPosition, mummy.Stats.BreakLoSRoamRadius));
    }

    public override void OnTakeDamage(Mummy mummy)
    {
        mummy.SetState(mummy.stunnedState, new MummyExitStateArgs(null, lastSeenPosition, mummy.breakLOSState));
    }
}
