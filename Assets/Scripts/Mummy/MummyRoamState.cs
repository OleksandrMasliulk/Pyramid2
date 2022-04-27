using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MummyRoamState : MummyState
{
    private Transform destinationPoint;

    private float timeToNextSenseTick;

    public override void EnterState(Mummy mummy, MummyExitStateArgs args)
    {
        Debug.LogWarning("Mummy entered Roam state");

        mummy.GetMovementController().SetSpeed(mummy.GetParameters().roamMoveSpeed);
        GetRoamPosition(mummy);

        timeToNextSenseTick = mummy.GetParameters().senseTickTime;
    }

    public override void ExitState(Mummy mummy)
    {
    }

    public override void StateTick(Mummy mummy)
    {
        if (mummy.GetMovementController().isAtDestination())
        {
            DestroyDestinationPoint(mummy, destinationPoint);
            GetRoamPosition(mummy);
        }

        if (timeToNextSenseTick <= 0f)
        {
            PlayerController player = SensePlayer(mummy);
            if (player != null)
            {
                Debug.Log("Player seeked");
                mummy.SetState(mummy.chaseState, new MummyExitStateArgs(player, player.transform.position));
                return;
            }
            timeToNextSenseTick = mummy.GetParameters().senseTickTime;
        }
        else
        {
            timeToNextSenseTick -= Time.deltaTime;
        }
    }

    public void GetRoamPosition(Mummy mummy) 
    {
        GameObject destPoint = new GameObject("Mummy Dest Point");

        Vector3 target;
        if (PlayerController.Instance != null && PlayerController.Instance.GetPlayerParameters().isAlive)
        {
            target = PlayerController.Instance.transform.position;
        }
        else
        {
            target = mummy.transform.position;
        }

        Vector3 pos = GetRandomPosition(target, mummy.GetParameters().roamRadius);

        while (!Map.Instance.IsPointWalkable(pos))
        {
            pos = GetRandomPosition(target, mummy.GetParameters().roamRadius);
        }

        destPoint.transform.position = pos;
        destinationPoint = destPoint.transform;
        mummy.GetMovementController().SetTarget(destPoint.transform); 
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

        Collider2D col = Physics2D.OverlapCircle(mummy.transform.position, mummy.GetParameters().losRadius, mummy.GetParameters().senseLayer);
        if (col != null)
        {
            player = col.GetComponent<PlayerController>();
        }

        return player;
    }
}
