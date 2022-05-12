using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bot : MonoBehaviour
{
    public AIPath aiPath;
    public AIDestinationSetter destSetter;

    public Animator anim;
    public SpriteRenderer sprite;

    private void Update()
    {
        if (Vector3.Distance(transform.position, destSetter.target.position) <= .1f)
        {
            ReachTarget();
        }
        SetAnimation(aiPath.desiredVelocity.normalized);
    }

    private void ReachTarget()
    {
        aiPath.canMove = false;
        Destroy(this.gameObject);
    }

    private void SetAnimation(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        anim.SetFloat("Horizontal", aiPath.desiredVelocity.normalized.x);
        anim.SetFloat("Vertical", aiPath.desiredVelocity.normalized.y);
    }
}
