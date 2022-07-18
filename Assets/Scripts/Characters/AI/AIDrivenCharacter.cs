using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AIDrivenCharacter : CharacterBase
{
    [SerializeField] protected IPathfindingMovement _movementHandler;
    public IPathfindingMovement MovementHandler => _movementHandler;

    public override void InitCharacter(AssetReference stats)
    {
    }
}
