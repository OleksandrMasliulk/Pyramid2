using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{
    public MummyParameters parameters;
    public MummyMovement movement;

    private MummyState state;

    public MummyAttackState attackState = new MummyAttackState();
    public MummyChaseState chaseState = new MummyChaseState();
    public MummyRoamState patrolState = new MummyRoamState();
    public MummySenseState senseState = new MummySenseState();

    private void Awake()
    {
        parameters = GetComponent<MummyParameters>();
        movement = GetComponent<MummyMovement>();

        Player.Instance.OnLowSanity += SensePlayer;
    }

    private void Start()
    {
        SetState(patrolState);
    }

    public void SetState(MummyState _state)
    {
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
        Player.Instance.OnLowSanity -= SensePlayer;
    }
}
