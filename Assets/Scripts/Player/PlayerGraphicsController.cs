using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    private Vector2 lastDirection = Vector2.down;

    public void SetIdle()
    {
        animator.SetBool("Moving", false);
        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
    }

    public void SetMovementState(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        animator.SetBool("Moving", true);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);

        lastDirection = direction;
    }

    public void SetDie()
    {
        animator.SetTrigger("Die");
    }

    public void SetInterract()
    {
        animator.SetTrigger("Interract");
    }

    public void DisableRenderer()
    {
        sprite.enabled = false;
    }

    public void EnableRenderer()
    {
        sprite.enabled = true;
    }
}
