using UnityEngine;

public abstract class NPCBase : CharacterBase {
    [SerializeField] protected AIPathfindingMovement _movementController;
    public AIPathfindingMovement MovementController => _movementController;
}
