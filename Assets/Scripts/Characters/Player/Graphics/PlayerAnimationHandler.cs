using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerAnimationHandler : CharacterAnimationHandler {
    [SerializeField] private AssetReference _aliveController;
    [SerializeField] private AssetReference _ghostController;

    public override void SetMovementDirection(Vector2 direction) => base.SetMovementDirection(direction);

    public void DisableRenderer() => _renderer.enabled = false;

    public void EnableRenderer() => _renderer.enabled = true;

    public async void SetGhostAnimationHandler() {
        AnimatorOverrideController controller = await _ghostController.LoadAssetAsyncSafe<AnimatorOverrideController>();
        _animator.runtimeAnimatorController = controller;
        _animator.Rebind();
    }

    public async void SetAliveAniationHandler() {
        RuntimeAnimatorController controller = await _aliveController.LoadAssetAsyncSafe<RuntimeAnimatorController>();
        _animator.runtimeAnimatorController = controller;
        _animator.Rebind();
    }

    private void OnDestroy() {
        _aliveController.ReleaseAssetSafe();
        _ghostController.ReleaseAssetSafe();
    }
}
