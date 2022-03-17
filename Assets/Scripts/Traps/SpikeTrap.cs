using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : TrapMaster
{
    protected override void Trigger(Player target)
    {
        base.Trigger(target);

        Debug.LogWarning("SPIKE TRAP TRIGGERED");
    }
}
