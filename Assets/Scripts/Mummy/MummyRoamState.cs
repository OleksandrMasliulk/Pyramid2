using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyRoamState : MummyState
{
    private Player player;

    private int currentPathNode;
    private List<PathfindingNode> path;
    private float reachNodeDistance = 1f;

    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Roam state");
        currentPathNode = -1;

        player = Player.Instance;
    }

    public override void ExitState(Mummy mummy)
    {
        player = null;
    }

    public override void StateTick(Mummy mummy)
    {
        if (currentPathNode != -1)
        {
            Vector3 nextPathNode = path[currentPathNode].GetWorldPos();
            mummy.movement.MoveTo(nextPathNode, mummy.parameters.roamMoveSpeed);

            if (Vector3.Distance(mummy.transform.position, nextPathNode) < reachNodeDistance)
            {
                currentPathNode++;
                if (currentPathNode >= path.Count)
                {
                    currentPathNode = -1; 
                }
            }
        }
        else
        {
            path = GetRoamPosition(mummy.transform.position, mummy.parameters.roamRadius, mummy);
            currentPathNode = 0;
        }

        float distance = Vector3.Distance(mummy.transform.position, player.transform.position);

        if (distance <= mummy.parameters.losRadius)
        {
            mummy.SetState(mummy.chaseState);
            ExitState(mummy);
            return;
        }
    }

    private List<PathfindingNode> GetRoamPosition(Vector3 target, float range, Mummy mummy)
    {
        Vector3 randPos = GetRandomPosition(target, range);
        List<PathfindingNode> path = Pathfinding.Instance.FindPath(mummy.transform.position.x, mummy.transform.position.y, randPos.x, randPos.y);

        while (path == null)
        {
            randPos = GetRandomPosition(target, range);
            path = Pathfinding.Instance.FindPath(mummy.transform.position.x, mummy.transform.position.y, randPos.x, randPos.y);
        }

        return path;
    }

    private Vector3 GetRandomPosition(Vector3 target, float range)
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        return target + randomDirection * range;
    }
}
