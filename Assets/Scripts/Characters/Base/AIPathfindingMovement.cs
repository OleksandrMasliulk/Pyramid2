using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Pathfinding;

public class AIPathfindingMovement : MonoBehaviour, IPathfindingMove
{
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private Seeker _seeker;
    [SerializeField] private AIDestinationSetter _destSetter;

    private Transform _target;
    private CancellationTokenSource cts;
    private CancellationToken token;

    private void Awake()
    {
        cts = new CancellationTokenSource();
    }

    public async Task Move(Vector3 target)
    {
        SetTarget(target);

        await new Task(() =>
        {
            token.ThrowIfCancellationRequested();

            while (true)
            {
                _aiPath.OnTargetReached();
                if (cts.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
        }, token);
        Debug.LogWarning("!!! Lambda WORKED!!!!");
        Destroy(_target.gameObject);
        _target = null;
    }

    public void SetTarget(Vector3 target)
    {
        _target = new GameObject("AI target").transform;

        _destSetter.target = _target;
    }

    public void CancelMoveTask()
    {
        cts.Cancel();
        Destroy(_target.gameObject);
        _destSetter.target = null;
    }

    public Vector2 GetMovementDirection()
    {
        return _aiPath.desiredVelocity.normalized;
    }

    public void SetSpeed(float newSpeed)
    {
        _aiPath.maxSpeed = newSpeed;
    }

    public void SetCanMove(bool newValue)
    {
        _aiPath.canMove = newValue;
    }
}
