using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RoamNPC : NPCBase
{
    [SerializeField] private Transform target;

    private async void Start()
    {
        await MovementController.Move(target.position);
        ReachTarget();
    }

    private void Update()
    {
        GraphicsController.SetMovementDirection(MovementController.GetMovementDirection());
    }

    private void ReachTarget()
    {
        Destroy(this.gameObject);
    }

    public override void TakeDamage(int damage)
    {
    }
}
