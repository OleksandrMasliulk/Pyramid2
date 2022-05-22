using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MummyPathfindingMovement : MonoBehaviour
{
    private Mummy mummy;

    public AIPath aiPath;
    public AIDestinationSetter destSetter;
    public Seeker seeker;

    private bool isMoving;

    private void Awake()
    {
        mummy = GetComponent<Mummy>();
    }

    private void Update()
    {
        if (aiPath.desiredVelocity.magnitude >= .5f)
        {
            isMoving = true;
            AudioManager.PlaySound(AudioManager.Sound.MummyWalk, transform.position, .3f);
            mummy.GetGraphicsController().SetMovementDirection(aiPath.desiredVelocity.normalized);
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

    public void SetCanMove(bool value)
    {
        aiPath.canMove = value;
    }
}
