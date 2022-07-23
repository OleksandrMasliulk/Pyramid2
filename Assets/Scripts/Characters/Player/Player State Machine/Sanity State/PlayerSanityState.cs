using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSanityState 
{
    public abstract void OnStateEnter(PlayerDrivenCharacter character);
    public abstract void OnStateExit(PlayerDrivenCharacter character);
}
