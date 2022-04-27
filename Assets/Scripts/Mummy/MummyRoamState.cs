using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MummyRoamState : MummyState
{
    private Transform destinationPoint;

    private Transform target;
    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Roam state");

        mummy.GetMovementController().SetSpeed(mummy.GetParameters().roamMoveSpeed);

        if (PlayerController.Instance.GetPlayerParameters().isAlive)
        {
            target = PlayerController.Instance.transform;
        }
        else
        {
            target = mummy.transform;
        }
        GetRoamPosition(mummy);
    }

    public override void ExitState(Mummy mummy)
    {
        target = null;
    }

    public override void StateTick(Mummy mummy)
    {
        if (mummy.GetMovementController().isAtDestination())
        {
            DestroyDestinationPoint(mummy, destinationPoint);
            GetRoamPosition(mummy);
        }

        float distance = Vector3.Distance(mummy.transform.position, target.transform.position);

        if (distance <= mummy.GetParameters().losRadius)
        {
            Debug.Log("Player seeked");
            mummy.SetState(mummy.chaseState);
            return;
        }
    }

    public void GetRoamPosition(Mummy mummy) 
    {
        GameObject destPoint = new GameObject("Mummy Dest Point");
        Vector3 pos = GetRandomPosition(target.transform.position, mummy.GetParameters().roamRadius);

        while (!Map.Instance.IsPointWalkable(pos))
        {
            pos = GetRandomPosition(target.transform.position, mummy.GetParameters().roamRadius);
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
}
