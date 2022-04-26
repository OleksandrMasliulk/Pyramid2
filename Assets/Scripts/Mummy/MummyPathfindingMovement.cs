using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MummyPathfindingMovement : MonoBehaviour
{
    public AIPath aiPath;
    public AIDestinationSetter destSetter;
    public Seeker seeker;

    private bool isMoving;

    private void Update()
    {
        if (aiPath.desiredVelocity.magnitude >= .5f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public void SetSpeed(float speed)
    {
        aiPath.maxSpeed = speed;
    } 

    public void SetTarget(Transform target) 
    {
        destSetter.target = target;
    }

    public bool GetIsMoving()
    {
        return isMoving;
    }

    public bool isAtDestination()
    {
        return aiPath.reachedDestination;
    }
}
