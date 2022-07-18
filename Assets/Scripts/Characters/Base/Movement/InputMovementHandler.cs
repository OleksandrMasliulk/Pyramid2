using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementHandler : MonoBehaviour, IMovement
{
    private CharacterBase _character;

    private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;

    private IListenAxisInput _inputHandler;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _character = GetComponent<CharacterBase>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Init(IListenAxisInput inputHandler, float speed)
    {
        _inputHandler = inputHandler;
        _movementSpeed = speed;
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
            return;
        }

        _rigidbody.MovePosition(transform.position + (Vector3)direction.normalized * _movementSpeed * Time.fixedDeltaTime);
        _character.AnimationHandler.SetMoving();
        _character.AnimationHandler.SetMovementDirection(direction);
        _character.VFXHandler.SpawnParticles(_character.VFXHandler.StepParticles);

    }

    public void SetSpeed(float speed)
    {
        _movementSpeed = speed;
    }
}
