using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyGraphicsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

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

    public void SetStunned(bool value)
    {
        animator.SetBool("Stunned", value);
    }
}
