using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour, IDamageable
{
    private MummyParameters parameters;
    private MummyPathfindingMovement movement;
    private MummyGraphicsController graphics;

    private MummyState state;

    public MummyAttackState attackState = new MummyAttackState();
    public MummyChaseState chaseState = new MummyChaseState();
    public MummyRoamState patrolState = new MummyRoamState();
    public MummySenseState senseState = new MummySenseState();
    public MummyBreakLOSState breakLOSState = new MummyBreakLOSState();
    public MummyStunnedState stunnedState = new MummyStunnedState();

    private void Awake()
    {
        parameters = GetComponent<MummyParameters>();
        movement = GetComponent<MummyPathfindingMovement>();
        graphics = GetComponent<MummyGraphicsController>();

        
    }

    private void Start()
    {
        PlayerController.Instance.GetPlayerSanityController().OnLowSanity += SensePlayer;
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
        SetState(senseState, new MummyExitStateArgs(targetPlayer, targetPlayer.transform.position, state));
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

    public MummyGraphicsController GetGraphicsController()
    {
        return graphics;
    }

    public void TakeDamage(int damage)
    {
        state.OnTakeDamage(this);
    }
}

public class MummyExitStateArgs
{
    public PlayerController playerSeeked;
    public Vector3 lastSeenPosition;
    public MummyState lastState;
    public MummyExitStateArgs(PlayerController playerSeeked, Vector3 lastSeenPosition, MummyState lastState)
    {
        this.playerSeeked = playerSeeked;
        this.lastSeenPosition = lastSeenPosition;
        this.lastState = lastState;
    }
}
