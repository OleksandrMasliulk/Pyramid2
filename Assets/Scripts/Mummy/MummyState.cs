using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MummyState
{
    protected Mummy mummy;

    public void SetMummy(Mummy _mummy)
    {
        mummy = _mummy;
    }

    public abstract void ChaseState();

    public abstract void PatrolState();

    public abstract void SenseState();

}
