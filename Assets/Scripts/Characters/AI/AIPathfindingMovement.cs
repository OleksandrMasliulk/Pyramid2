using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Pathfinding;

public class AIPathfindingMovement : MonoBehaviour, IPathfindingMovement
{
    [SerializeField] private AIPath _aiPath;
    [SerializeField] private Seeker _seeker;
    [SerializeField] private AIDestinationSetter _destSetter;
    public float MovementSpeed { get; private set; }
    public bool ReachedTarget => _aiPath.reachedDestination;

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
        _seeker = GetComponent<Seeker>();
        _destSetter = GetComponent<AIDestinationSetter>();
    }

    private void Init(float moveSpeed)
    {
        MovementSpeed = moveSpeed;
        _aiPath.maxSpeed = MovementSpeed;
    }

    public void RemoveTarget()
    {
        if (_destSetter.target == null)
            return;

        if (_destSetter.target.GetComponent<CharacterBase>() == null)
            Destroy(_destSetter.target.gameObject);

        _destSetter.target = null;
    }

    public void SetTarget(Transform target)
    {
        RemoveTarget();

        _destSetter.target = target;
    }

    public void SetTarget(Vector2 target)
    {
        RemoveTarget();

        GameObject go = new GameObject("AI Pathfinding Target");
        _destSetter.target = go.transform;
    }

    public void SetSpeed(float value)
    {
        MovementSpeed = value;
        _aiPath.maxSpeed = MovementSpeed;
    }

    public void Move()
    {
    }
}
