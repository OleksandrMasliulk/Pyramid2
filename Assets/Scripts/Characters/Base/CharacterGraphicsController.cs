using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGraphicsController : MonoBehaviour
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
}