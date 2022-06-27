using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Pathfinding;

public class AIPathfindingMovement : MonoBehaviour, IPathfindingMove
{
    [SerializeField] private AIPath _aiPath;
    public bool ReachedTarget => _aiPath.reachedEndOfPath;
    [SerializeField] private Seeker _seeker;
    [SerializeField] private AIDestinationSetter _destSetter;

    private Transform _target;

    //public async Task Move(Vector3 target)
    //{
    //    SetTarget(target);
    //   // Task moveTask = new Task(async () =>
    //   //{
    //   //    Debug.Log("123");
    //   //    token.ThrowIfCancellationRequested();

    //   //    while (!_aiPath.reachedEndOfPath)
    //   //    {
    //   //        if (cts.IsCancellationRequested)
    //   //        {
    //   //            token.ThrowIfCancellationRequested();
    //   //        }
    //   //    }
    //   //    Debug.Log("321");
    //   //    await Task.Yield();
    //   //}, token);
    //    //moveTask.Start();

    //    Debug.LogWarning("!!! Lambda WORKED!!!!");

    //    Destroy(_target.gameObject);
    //    _target = null;
    //}

    public void SetTarget(Vector3 target)
    {
        DestroyTarget();
        _target = new GameObject("AI target").transform;
        _target.position = target;

        _destSetter.target = _target;
    }

    private void DestroyTarget()
    {
        if (_target == null)
            return;

        Destroy(_target.gameObject);
        _destSetter.target = null;
    }

    //public void CancelMoveTask()
    //{
    //    cts.Cancel();
    //    Destroy(_target.gameObject);
    //    _destSetter.target = null;
    //}

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

    public Task Move(Vector3 target)
    {
        throw new System.NotImplementedException();
    }
}
