using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Mummy : EnemyBase, IDamageable
{
    public new MummyGraphicsController AnimationHandler => (MummyGraphicsController)_animationHandler;

    private MummyState state;

    public MummyAttackState attackState = new MummyAttackState();
    public MummyChaseState chaseState = new MummyChaseState();
    public MummyRoamState roamState = new MummyRoamState();
    public MummySenseState senseState = new MummySenseState();
    public MummyBreakLOSState breakLOSState = new MummyBreakLOSState();
    public MummyStunnedState stunnedState = new MummyStunnedState();

    private void Start()
    {
        //foreach (PlayerController pc in UnitManager.Instance.PlayerList)
        //{
        //    pc.SanityController.OnLowSanity += SensePlayer;
        //}
        //SetState(roamState, null);
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

    //private void SensePlayer(PlayerController targetPlayer)
    //{
    //    SetState(senseState, new MummyExitStateArgs(targetPlayer, targetPlayer.transform.position, state));
    //}

    //private void OnDisable()
    //{
    //    foreach (PlayerController pc in UnitManager.Instance.PlayerList)
    //    {
    //        pc.SanityController.OnLowSanity -= SensePlayer;
    //    }
    //}

    //public override void TakeDamage(int damage)
    //{
    //    state.OnTakeDamage(this);
    //}

    public override void InitCharacter(AssetReference stats)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damage)
    {
        //throw new System.NotImplementedException();
    }
}

public class MummyExitStateArgs
{
    //public PlayerController playerSeeked;
    //public Vector3 lastSeenPosition;
    //public MummyState lastState;
    //public MummyExitStateArgs(PlayerController playerSeeked, Vector3 lastSeenPosition, MummyState lastState)
    //{
    //    this.playerSeeked = playerSeeked;
    //    this.lastSeenPosition = lastSeenPosition;
    //    this.lastState = lastState;
    //}
}
