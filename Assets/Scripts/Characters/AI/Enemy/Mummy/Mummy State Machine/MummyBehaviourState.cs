using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MummyBehaviourState
{
    public abstract void EnterState(Mummy mummy);
    public abstract void ExitState(Mummy mummy);
    public abstract void StateTick(Mummy mummy);
}
