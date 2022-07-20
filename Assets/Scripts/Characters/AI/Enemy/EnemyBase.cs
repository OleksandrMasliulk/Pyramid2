using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyBase : CharacterBase
{
    [SerializeField] protected AIPathfindingMovement _movementHandler;
    public AIPathfindingMovement MovementHandler => _movementHandler;
}
