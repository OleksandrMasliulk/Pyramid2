using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBase : CharacterBase
{
    [SerializeField] protected AIPathfindingMovement _movementController;
    public AIPathfindingMovement MovementController => _movementController;
    public abstract override void TakeDamage(int damage);
}
