using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.AddressableAssets;

public class RoamNPC : NPCBase
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        //GraphicsController.SetMovementDirection(MovementController.GetMovementDirection());
    }

    private void ReachTarget()
    {
        Destroy(this.gameObject);
    }

    public override void InitCharacter(AssetReference stats)
    {
    }
}
