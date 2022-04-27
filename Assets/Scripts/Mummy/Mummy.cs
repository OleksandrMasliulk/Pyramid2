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
    public MummyBreakLOSState breakLOSState = new MummyBreakLOSState();

    private void Awake()
    {
        parameters = GetComponent<MummyParameters>();
        movement = GetComponent<MummyPathfindingMovement>();

        PlayerController.Instance.GetPlayerSanityController().OnLowSanity += SensePlayer;
    }

    private void Start()
    {
        SetState(patrolState, null);
    }

    public void SetState(MummyState _state, MummyExitStateArgs args)
    {
        if (state != null)
        {
            state.ExitState(this);
        }
        state = _state;
        state.EnterState(this, args);
    }

    private void Update()
    {
        state.StateTick(this);
    }

    private void SensePlayer(PlayerController targetPlayer)
    {
        SetState(senseState, new MummyExitStateArgs(targetPlayer, targetPlayer.transform.position));
    }

    private void OnDisable()
    {
        PlayerController.Instance.GetPlayerSanityController().OnLowSanity -= SensePlayer;
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

public class MummyExitStateArgs
{
    public PlayerController playerSeeked;
    public Vector3 lastSeenPosition;

    public MummyExitStateArgs(PlayerController playerSeeked, Vector3 lastSeenPosition)
    {
        this.playerSeeked = playerSeeked;
        this.lastSeenPosition = lastSeenPosition;
    }
}
