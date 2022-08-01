using UnityEngine.AddressableAssets;

public class AIDrivenCharacter : CharacterBase {
    public IPathfindingMovement MovementHandler => _movementHandler;

    protected IPathfindingMovement _movementHandler;

    public override void InitCharacter(AssetReference stats) {
    }
}
