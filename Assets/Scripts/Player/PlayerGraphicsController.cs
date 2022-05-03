using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    //[SerializeField] private AnimatorOverrideController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    public void SetMovementDirection(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }

    public void SetDie()
    {
        animator.SetTrigger("Die");
    }

    public void DisableRenderer()
    {
        sprite.enabled = false;
    }

    public void EnableRenderer()
    {
        sprite.enabled = true;
    }

    public void SetGhostGraphics()
    {
        animator.runtimeAnimatorController = ghostController;
        animator.SetTrigger("Ghost");
    }
}
