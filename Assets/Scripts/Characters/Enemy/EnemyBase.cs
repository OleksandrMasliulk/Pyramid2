using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyBase : CharacterBase
{
    [SerializeField] protected AIPathfindingMovement _movementController;
    public AIPathfindingMovement MovementController => _movementController;

    public override abstract void TakeDamage(int damage);
}
