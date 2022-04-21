using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySenseState : MummyState
{
    private Player player;

    private List<PathfindingNode> path;
    private int currentPathNode;
    private float reachNodeDistance = .5f;

    private float recalculatePathTickTimer = 1f;
    private float timeToRecalculatePath;
    public override void EnterState(Mummy mummy)
    {
        Debug.LogWarning("Mummy entered Sense State");
        player = Player.Instance;

        CalculatePathToTarget(mummy);
        timeToRecalculatePath = recalculatePathTickTimer;
    }

    public override void ExitState(Mummy mummy)
    {
        player = null;
    }

    public override void StateTick(Mummy mummy)
    {
        if (timeToRecalculatePath <= 0f)
        {
            CalculatePathToTarget(mummy);
            timeToRecalculatePath = recalculatePathTickTimer;
        }
        else
        {
            timeToRecalculatePath -= Time.deltaTime;
        }

        if (currentPathNode != -1)
        {
            Vector3 nextPathNode = path[currentPathNode].GetWorldPos();
            mummy.movement.MoveTo(nextPathNode, mummy.parameters.senseMoveSpeed);

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
            CalculatePathToTarget(mummy);
        }

        float distance = Vector3.Distance(mummy.transform.position, player.transform.position);

        if (distance <= mummy.parameters.attackDistance)
        {
            mummy.SetState(mummy.attackState);
            ExitState(mummy);
            return;
        }

        if (player.GetSanity() > 25)
        {
            mummy.SetState(mummy.patrolState);
            ExitState(mummy);
            return;
        }
    }

    private void CalculatePathToTarget(Mummy mummy)
    {
        path = Pathfinding.Instance.FindPath(mummy.transform.position.x, mummy.transform.position.y, player.transform.position.x, player.transform.position.y);
        currentPathNode = 0;
    }
}
