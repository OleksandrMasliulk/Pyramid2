using UnityEngine;

public interface IPathfindingMovement : ICanMove
{
    public void SetTarget(Transform target);
    public void SetTarget(Vector2 target);
    public void RemoveTarget();
}
