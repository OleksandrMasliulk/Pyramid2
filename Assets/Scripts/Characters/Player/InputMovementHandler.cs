using UnityEngine;

public class InputMovementHandler : MonoBehaviour, ICanMove {
    private CharacterBase _character;
    public float MovementSpeed { get; private set; }

    private PlayerInputController _inputHandler;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _character = GetComponent<CharacterBase>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputHandler = GetComponent<PlayerInputController>();
    }

    public void Init(float speed) => MovementSpeed = speed;

    private void FixedUpdate() {
        if (_inputHandler == null)
            return;

        Move();
    }

    public void Move() {
        Vector2 direction = _inputHandler.CharacterActions.Move.ReadValue<Vector2>();
        if (direction.magnitude <= 0f) {
            _character.AnimationHandler.SetIdle();
            //_character.VFXHandler.DisableStepParticles();
            return;
        }

        _rigidbody.MovePosition(transform.position + (Vector3)direction.normalized * MovementSpeed * Time.fixedDeltaTime);
        _character.AnimationHandler.SetMoving();
        _character.AnimationHandler.SetMovementDirection(direction);
        //_character.VFXHandler.EnableStepParticles();

    }

    public void SetSpeed(float speed) => MovementSpeed = speed;
}
