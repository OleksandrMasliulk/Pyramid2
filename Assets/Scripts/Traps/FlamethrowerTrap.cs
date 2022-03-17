using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrap : TrapMaster
{
    protected override void Trigger(Player target)
    {
        base.Trigger(target);

        Debug.LogWarning("FLAMETHROWER TRAP TRIGGERED");
    }
}
