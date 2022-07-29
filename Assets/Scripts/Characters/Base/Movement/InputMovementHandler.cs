using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementHandler : MonoBehaviour, ICanMove
{
    private CharacterBase _character;
    public float MovementSpeed { get; private set; }

    private IListenAxisInput _inputHandler;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _character = GetComponent<CharacterBase>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputHandler = GetComponent<IListenAxisInput>();
    }
    
    public void Init(float speed)
    {
        MovementSpeed = speed;
    }

    private void FixedUpdate()
    {
        if (_inputHandler == null)
            return;

        Move();
    }

    public void Move()
    {
        Vector2 direction = new Vector2(_inputHandler.Horizontal, _inputHandler.Vertical);
        if (direction.magnitude <= 0f)
        {
            _character.AnimationHandler.SetIdle();
            _character.VFXHandler.DisableStepParticles();
            return;
        }

        _rigidbody.MovePosition(transform.position + (Vector3)direction.normalized * MovementSpeed * Time.fixedDeltaTime);
        _character.AnimationHandler.SetMoving();
        _character.AnimationHandler.SetMovementDirection(direction);
        _character.VFXHandler.EnableStepParticles();

    }

    public void SetSpeed(float speed)
    {
        MovementSpeed = speed;
    }
}
