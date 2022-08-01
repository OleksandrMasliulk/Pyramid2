using UnityEngine;

public class PlayerAnimationHandler : CharacterAnimationHandler {
    [SerializeField] private RuntimeAnimatorController aliveController;
    [SerializeField] private AnimatorOverrideController ghostController;

    public override void SetMovementDirection(Vector2 direction) => base.SetMovementDirection(direction);

    public void DisableRenderer() => _renderer.enabled = false;

    public void EnableRenderer() => _renderer.enabled = true;

    public void SetGhostAnimationHandler() {
        _animator.runtimeAnimatorController = ghostController;
        _animator.Rebind();
    }

    public void SetAliveAniationHandler() {
        _animator.runtimeAnimatorController = aliveController;
        _animator.Rebind();
    }
}
