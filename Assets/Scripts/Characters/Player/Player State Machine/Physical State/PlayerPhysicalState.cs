using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerPhysicalState
{
    public abstract void OnStateEnter(PlayerDrivenCharacter player);
    public abstract void OnStateExit(PlayerDrivenCharacter player);
}
