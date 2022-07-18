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

    [SerializeField] private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
        _seeker = GetComponent<Seeker>();
        _destSetter = GetComponent<AIDestinationSetter>();
    }

    public void RemoveTarget()
    {
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
}
