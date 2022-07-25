using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MummyPhysicalState
{
    public abstract void OnStateEnter(Mummy mummy);
    public abstract void OnStateExit(Mummy mummy);
}
