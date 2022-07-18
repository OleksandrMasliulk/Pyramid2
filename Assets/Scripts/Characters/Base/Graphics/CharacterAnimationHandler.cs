using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected SpriteRenderer _renderer;

    public virtual void SetMovementDirection(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }

        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);
    }

    public void SetMoving()
    {
        _animator.SetTrigger("Moving");
    }

    public void SetDie()
    {
        _animator.SetTrigger("Die");
    }

    public void SetIdle()
    {
        _animator.SetTrigger("Idle");
    }
}