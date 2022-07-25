using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyNormalState : MummyPhysicalState
{
    public override void OnStateEnter(Mummy mummy)
    {
        mummy.MovementHandler.CanMove = true;
    }

    public override void OnStateExit(Mummy mummy)
    {
        
    }
}
