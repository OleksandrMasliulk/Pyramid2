using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{
    private MummyParameters parameters;
    private MummyPathfindingMovement movement;

    private MummyState state;

    public MummyAttackState attackState = new MummyAttackState();
    public MummyChaseState chaseState = new MummyChaseState();
    public MummyRoamState patrolState = new MummyRoamState();
    public MummySenseState senseState = new MummySenseState();

    private void Awake()
    {
        parameters = GetComponent<MummyParameters>();
        movement = GetComponent<MummyPathfindingMovement>();

        PlayerController.Instance.OnLowSanity += SensePlayer;
    }

    private void Start()
    {
        SetState(patrolState);
    }

    public void SetState(MummyState _state)
    {
        if (state != null)
        {
            state.ExitState(this);
        }
        state = _state;
        state.EnterState(this);
    }

    private void Update()
    {
        state.StateTick(this);
    }

    private void SensePlayer()
    {
        SetState(senseState);
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnLowSanity -= SensePlayer;
    }

    public MummyPathfindingMovement GetMovementController()
    {
        return movement;
    }

    public MummyParameters GetParameters()
    {
        return parameters;
    }
}
