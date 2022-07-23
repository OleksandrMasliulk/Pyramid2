using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected SpriteRenderer _renderer;

    [SerializeField] private Transform _itemSockets;
    public Transform Sockets => _itemSockets;
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

        SetSocketsDirection(direction);
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

    public void SetSocketsDirection(Vector3 dir)
    {
        float m = 90;
        if (dir.x == 0 && dir.y == 0)
        {
            m = 180;
        }

        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _itemSockets.rotation = Quaternion.Euler(0f, 0f, rot_z - m);
    }
}